using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperToolkit.Core.Extensions
{
    public static class TaskExtensions
    {
        public static IEnumerable<Task<T>> InCompletionOrder<T>(this IEnumerable<Task<T>> source)
        {
            var inputs = source.ToList();
            var boxes = inputs.Select(x => new TaskCompletionSource<T>()).ToList();

            var currentIndex = -1;
            foreach (var task in inputs)
            {
                task.ContinueWith(completed =>
                {
                    var nextBox = boxes[Interlocked.Increment(ref currentIndex)];
                    PropagateResult(completed, nextBox);
                }, TaskContinuationOptions.ExecuteSynchronously);
            }

            return boxes.Select(box => box.Task);
        }

        private static void PropagateResult<T>(Task<T> completedTask,
            TaskCompletionSource<T> completionSource)
        {
            switch (completedTask.Status)
            {
                case TaskStatus.RanToCompletion:
                    completionSource.TrySetResult(completedTask.Result);
                    break;
                case TaskStatus.Canceled:
                    completionSource.TrySetCanceled();
                    break;
                case TaskStatus.Faulted:
                    completionSource.TrySetException(completedTask.Exception);
                    break;
                default:
                    throw new ArgumentException("Task was not completed");
            }
        }
    }
}

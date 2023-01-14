using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Nito.AsyncEx;

namespace LogMeTender.TestUtils
{
    /// <summary>
    /// A <see cref="IAsyncEnumerable{T}"/> that yield values pushed by <see cref="Emit"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items yielded by the async enumerable.</typeparam>
    public class FakeAsyncEnumerable<T> : IAsyncEnumerable<T>
    {
        private readonly AsyncProducerConsumerQueue<T> _queue;

        /// <summary>
        /// Initialize a new instance of the <see cref="FakeAsyncEnumerable{T}"/> class.
        /// </summary>
        public FakeAsyncEnumerable() => _queue = new AsyncProducerConsumerQueue<T>();

        public void Emit(T value) => _queue.Enqueue(value);

        public void Complete() => _queue.CompleteAdding();

        public async IAsyncEnumerator<T>  GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                T item;
                try
                {
                    item = await _queue.DequeueAsync(cancellationToken);
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                
                yield return item;
            }
        }
    }
}
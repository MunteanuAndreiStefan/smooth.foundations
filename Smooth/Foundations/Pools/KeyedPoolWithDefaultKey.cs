using System;
using Smooth.Algebraics;
using Smooth.Dispose;

namespace Smooth.Pools {
	/// <summary>
	/// Pool that lends values of type T with an associated key of type K and defines a default key.
	/// </summary>
	public class KeyedPoolWithDefaultKey<K, T> : KeyedPool<K, T> {
		private readonly Either<K, Func<K>> defaultKey;

		/// <summary>
		/// Creates a new keyed pool with the specified creation delegate, reset delegate, and default key.
		/// </summary>
		public KeyedPoolWithDefaultKey(Func<K, T> create, Func<T, K> reset, K defaultKey) : base (create, reset) {
			this.defaultKey = Either<K, Func<K>>.Left(defaultKey);
		}

		/// <summary>
		/// Creates a new keyed pool with the specified creation delegate, reset delegate, and default key.
		/// </summary>
		public KeyedPoolWithDefaultKey(Func<K, T> create, Func<T, K> reset, Func<K> defaultKeyFunc) : base (create, reset) {
			defaultKey = Either<K, Func<K>>.Right(defaultKeyFunc);
		}

		/// <summary>
		/// Borrows a value with the default key from the pool.
		/// </summary>
		public T Borrow() {
			return Borrow(defaultKey.isLeft ? defaultKey.leftValue : defaultKey.rightValue());
		}

		/// <summary>
		/// Borrows a wrapped value with the default key from the pool.
		/// </summary>
		public Disposable<T> BorrowDisposable() {
			return BorrowDisposable(defaultKey.isLeft ? defaultKey.leftValue : defaultKey.rightValue());
		}
	}
}
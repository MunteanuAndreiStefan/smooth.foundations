﻿using System;
using System.Collections.Generic;
using Smooth.Algebraics;
using Smooth.Slinq;

namespace Smooth.Foundations.PatternMatching
{
    internal sealed class MatchFunctionSelector<T1, TResult>
    {
        private readonly Func<T1, TResult> _defaultFunction;

        private readonly List<Tuple<Func<T1, bool>, Func<T1, TResult>>> _predicatesAndFuncs =
            new List<Tuple<Func<T1, bool>, Func<T1, TResult>>>();

        public MatchFunctionSelector(Func<T1, TResult> defaultFunction)
        {
            _defaultFunction = defaultFunction;
        }

        public void AddPredicateAndAction(Func<T1, bool> test, Func<T1, TResult> action) => 
            _predicatesAndFuncs.Add(new Tuple<Func<T1, bool>, Func<T1, TResult>>(test, action));

        public TResult DetermineResultUsingDefaultIfRequired(T1 value)
        {
            var funcAndArgsPair =
                _predicatesAndFuncs
                .Slinq()
                .FirstOrNone((x, v) => x.Item1(v), value);
            return funcAndArgsPair.isSome ? funcAndArgsPair.value.Item2(value) : _defaultFunction(value);
        }

        public Option<TResult> DetermineResult(T1 value)
        {
            return _predicatesAndFuncs
                .Slinq()
                .FirstOrNone((tuple, p) => tuple.Item1(p), value)
                .Select((pair, p) => pair.Item2(p), value);
        }
    }

    internal sealed class MatchFunctionSelector<T1, T2, TResult>
    {
        private readonly Func<T1, T2, TResult> _defaultFunction;

        private readonly List<Tuple<Func<T1, T2, bool>, Func<T1, T2, TResult>>> _predicatesAndFuncs =
            new List<Tuple<Func<T1, T2, bool>, Func<T1, T2, TResult>>>();

        public MatchFunctionSelector(Func<T1, T2, TResult> defaultFunction)
        {
            _defaultFunction = defaultFunction;
        }

        public void AddTestAndAction(Func<T1, T2, bool> test, Func<T1, T2, TResult> action) =>
            _predicatesAndFuncs.Add(new Tuple<Func<T1, T2, bool>, Func<T1, T2, TResult>>(test, action));

        public TResult DetermineResultUsingDefaultIfRequired(Tuple<T1, T2> value)
        {
            var funcAndArgsPair =
                _predicatesAndFuncs
                .Slinq()
                .FirstOrNone((x, v) => x.Item1(v.Item1, v.Item2), value);
            return funcAndArgsPair.isSome
                       ? funcAndArgsPair.value.Item2(value.Item1, value.Item2)
                       : _defaultFunction(value.Item1, value.Item2);
        }

        public Option<TResult> DetermineResult(Tuple<T1, T2> value)
        {
            return _predicatesAndFuncs
                .Slinq()
                .FirstOrNone((tuple, p) => tuple.Item1(p.Item1, p.Item2), value)
                .Select((pair, p) => pair.Item2(p.Item1, p.Item2), value);
        }
    }

    internal sealed class MatchFunctionSelector<T1, T2, T3, TResult>
    {
        private readonly Func<T1, T2, T3, TResult> _defaultFunction;

        private readonly List<Tuple<Func<T1, T2, T3, bool>, Func<T1, T2, T3, TResult>>> _predicatesAndFuncs =
            new List<Tuple<Func<T1, T2, T3, bool>, Func<T1, T2, T3, TResult>>>();

        public MatchFunctionSelector(Func<T1, T2, T3, TResult> defaultFunction)
        {
            _defaultFunction = defaultFunction;
        }

        public void AddTestAndAction(Func<T1, T2, T3, bool> test, Func<T1, T2, T3, TResult> action) =>
            _predicatesAndFuncs.Add(new Tuple<Func<T1, T2, T3, bool>, Func<T1, T2, T3, TResult>>(test, action));

        public TResult DetermineResultUsingDefaultIfRequired(Tuple<T1, T2, T3> value)
        {
            var funcAndArgsPair =
                _predicatesAndFuncs
                .Slinq()
                .FirstOrNone((x, v) => x.Item1(v.Item1, v.Item2, v.Item3), value);
            return funcAndArgsPair.isSome
                       ? funcAndArgsPair.value.Item2(value.Item1, value.Item2, value.Item3)
                       : _defaultFunction(value.Item1, value.Item2, value.Item3);
        }

        public Option<TResult> DetermineResult(Tuple<T1, T2, T3> value)
        {
            return _predicatesAndFuncs
                .Slinq()
                .FirstOrNone((tuple, p) => tuple.Item1(p.Item1, p.Item2, p.Item3), value)
                .Select((pair, p) => pair.Item2(p.Item1, p.Item2, p.Item3), value);
        }
    }

    internal sealed class MatchFunctionSelector<T1, T2, T3, T4, TResult>
    {
        private readonly Func<T1, T2, T3, T4, TResult> _defaultFunction;

        private readonly List<Tuple<Func<T1, T2, T3, T4, bool>, Func<T1, T2, T3, T4, TResult>>> _predicatesAndFuncs =
            new List<Tuple<Func<T1, T2, T3, T4, bool>, Func<T1, T2, T3, T4, TResult>>>();

        public MatchFunctionSelector(Func<T1, T2, T3, T4, TResult> defaultFunction)
        {
            _defaultFunction = defaultFunction;
        }

        public void AddTestAndAction(Func<T1, T2, T3, T4, bool> test, Func<T1, T2, T3, T4, TResult> action) =>
            _predicatesAndFuncs.Add(new Tuple<Func<T1, T2, T3, T4, bool>, Func<T1, T2, T3, T4, TResult>>(test, action));

        public TResult DetermineResultUsingDefaultIfRequired(Tuple<T1, T2, T3, T4> value)
        {
            var funcAndArgsPair =
                _predicatesAndFuncs
                .Slinq()
                .FirstOrNone((x, v) => x.Item1(v.Item1, v.Item2, v.Item3, v.Item4), value);
            return funcAndArgsPair.isSome
                       ? funcAndArgsPair.value.Item2(value.Item1, value.Item2, value.Item3, value.Item4)
                       : _defaultFunction(value.Item1, value.Item2, value.Item3, value.Item4);
        }

        public Option<TResult> DetermineResult(Tuple<T1, T2, T3, T4> value)
        {
            return _predicatesAndFuncs
                .Slinq()
                .FirstOrNone((tuple, p) => tuple.Item1(p.Item1, p.Item2, p.Item3, p.Item4), value)
                .Select((pair, p) => pair.Item2(p.Item1, p.Item2, p.Item3, p.Item4), value);
        }
    }
}
﻿namespace ServerEngine.DataManagement
{
        public interface IWrapper
        {
                /// <summary>
                ///   Explicit ToString override, because wrapper structs' ToString will hide the properties
                /// </summary>
                /// <returns></returns>
                int Hash();
        }

        public interface IWrapper<out T> : IWrapper
        {
                T Value { get; }
        }
}

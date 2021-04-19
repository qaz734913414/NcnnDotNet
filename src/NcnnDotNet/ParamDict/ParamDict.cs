﻿using System;

// ReSharper disable once CheckNamespace
namespace NcnnDotNet
{

    public sealed class ParamDict : NcnnObject
    {

        #region Constructors

        public ParamDict()
        {
            var error = NativeMethods.paramdict_ParamDict_new(out var net);
            if (error != NativeMethods.ErrorType.OK)
                throw new NcnnException("Unknown Exception");

            this.NativePtr = net;
        }

        internal ParamDict(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentException("Can not pass IntPtr.Zero", nameof(ptr));

            this.NativePtr = ptr;
        }

        #endregion

        #region Methods

        public void Set(int id, int value)
        {
            this.ThrowIfDisposed();
            NativeMethods.paramdict_ParamDict_set(this.NativePtr, id, value);
        }

        public void Set(int id, float value)
        {
            this.ThrowIfDisposed();
            NativeMethods.paramdict_ParamDict_set2(this.NativePtr, id, value);
        }

        #region Overrides 

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.paramdict_ParamDict_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
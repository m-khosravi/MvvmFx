//
// DependencyPropertyChangedEventArgs.cs
//
// Author:
//   Chris Toshok (toshok@ximian.com)
//
// (C) 2007 Novell, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Bindings
{
    /// <summary>
    /// DependencyPropertyChangedEventArgs
    /// </summary>
    /// <remarks>This class isn't completely implemented.</remarks>
    [SuppressMessage("Microsoft.Naming", "CA1711", Justification = "Signature compatibility.")]
    public struct DependencyPropertyChangedEventArgs
    {
        public DependencyPropertyChangedEventArgs(DependencyProperty property, object oldValue, object newValue)
            : this()
        {
            Property = property;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public object NewValue { get; private set; }

        public object OldValue { get; private set; }

        public DependencyProperty Property { get; private set; }

        public override bool Equals(object obj)
        {
            if (!(obj is DependencyPropertyChangedEventArgs))
                return false;

            return Equals((DependencyPropertyChangedEventArgs) obj);
        }

        public bool Equals(DependencyPropertyChangedEventArgs args)
        {
            return (Property == args.Property &&
                    NewValue == args.NewValue &&
                    OldValue == args.OldValue);
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        public static bool operator !=(DependencyPropertyChangedEventArgs left, DependencyPropertyChangedEventArgs right)
        {
            throw new NotImplementedException("DependencyPropertyChangedEventArgs");
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        public static bool operator ==(DependencyPropertyChangedEventArgs left, DependencyPropertyChangedEventArgs right)
        {
            throw new NotImplementedException("DependencyPropertyChangedEventArgs");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

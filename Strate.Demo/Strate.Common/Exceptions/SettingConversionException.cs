﻿using System;
using System.Runtime.Serialization;

namespace Strate.Common
{
    /// <summary>
    ///     Represents a failure to convert a setting to the desired type.
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public class SettingConversionException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SettingConversionException"/> class.
        /// </summary>
        public SettingConversionException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SettingConversionException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SettingConversionException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SettingConversionException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference 
        ///     (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public SettingConversionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SettingConversionException"/> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="System.Runtime.Serialization.SerializationInfo" /> that holds the 
        ///     serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="System.Runtime.Serialization.StreamingContext" /> that 
        ///     contains contextual information about the source or destination.
        /// </param>
        protected SettingConversionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

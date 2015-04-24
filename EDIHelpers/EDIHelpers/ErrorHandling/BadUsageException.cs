using System;

#region "  � Copyright 2005-07 to Marcos Meli - http://www.marcosmeli.com.ar" 

// Errors, suggestions, contributions, send a mail to: marcos@EDIHelpers.com.

#endregion

namespace EDIHelpers.ErrorHandling
{
	/// <summary>Indicates the wrong usage of the library.</summary>
	public  class BadUsageException : EDIHelpersException
	{
		/// <summary>Creates an instance of an BadUsageException.</summary>
		/// <param name="message">The exception Message</param>
		protected internal BadUsageException(string message) : base(message)
		{
		}

//		/// <summary>Creates an instance of an BadUsageException.</summary>
//		/// <param name="message">The exception Message</param>
//		/// <param name="innerEx">The inner exception.</param>
//		protected internal BadUsageException(string message, Exception innerEx) : base(message, innerEx)
//		{
//		}

	}
}
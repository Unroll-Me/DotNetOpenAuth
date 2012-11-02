using System.Web;

namespace DotNetOpenAuth.OpenId.RelyingParty {
	/// <summary>
	/// Allows relying parties to disable validation of the return_to parameter.
	/// </summary>
	/// <remarks>
	/// This is a context-static property because I can't figure out how to get 
	/// any state from the originating OpenIdRelyingParty into the message 
	/// deserialization process where the return_to is validated.
	/// </remarks>
	public static class ReturnToValidationSuppression {
		static readonly object valueKey = new object();

		/// <summary>
		/// Indicates whether return_to validation is suppressed for the current HTTP request.
		/// </summary>
		/// <remarks>
		/// If this is set to true, the relying party must perform its own validation to prevent confused-deputy attacks.
		/// </remarks>
		public static bool IsSuppressed {
			get { return HttpContext.Current.Items.Contains(valueKey); }
			set {
				if (value)
					HttpContext.Current.Items[valueKey] = null;
				else
					HttpContext.Current.Items.Remove(valueKey);
			}
		}
	}
}

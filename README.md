This is a fork of the existing DotNetOpenAuth library that has been modified to meet our needs.

So far, I've made three changes:

 - Remove strong names (to allow the build to work)
  - I chose not to use our own keypair to avoid updating `InternalsVisibleTo`s
 - Allow OpenID relying parties to suppress `return_to` validation for OpenID [forwarding scenarios](https://github.com/DotNetOpenAuth/DotNetOpenAuth/issues/228)
 - Use `Uri.OriginalString` in the `Realm` class to preserve realms that don't have a path.
  - Our existing realm is `http://www.unroll.me` (no trailing `/` for the path); it is [currently impossible](https://github.com/DotNetOpenAuth/DotNetOpenAuth/issues/227) to use such a realm in stock DNOA.
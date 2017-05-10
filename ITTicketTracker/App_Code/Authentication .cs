using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;

/// <summary>
/// Summary description for Authentication
/// </summary>
public static class Authentication
{
	public static List<string> GetUserGroups()
	{
        try
        {
            IIdentity WinId = HttpContext.Current.User.Identity;
            WindowsIdentity wi = (WindowsIdentity)WinId;
            string userDomain = wi.Name.ToString();

            string[] split = userDomain.Split('\\');


            string domain = split[0];
            string username = split[1];

            List<string> usersGroup = GetGroupNames(username, domain);
            return usersGroup;
        }
        catch
        {
            return new List<string>();
        }

	}



    //FROM http://stackoverflow.com/questions/2188954/see-if-user-is-part-of-active-directory-group-in-c-sharp-asp-net
    private static List<string> GetGroupNames(string userName, string domain)
    {
        var pc = new PrincipalContext(ContextType.Domain, domain);
        var src = UserPrincipal.FindByIdentity(pc, userName).GetGroups(pc);
        var result = new List<string>();
        src.ToList().ForEach(sr => result.Add(sr.SamAccountName));
        return result;
    }

}
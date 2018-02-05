using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IS4Demo
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1","MyApi")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            //客戶端验证,没有用户名密码。在这里定义客戶端列表
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ro.client",

                    // 没有交互用户,使用clientid / secret进行身份验证
                    //AllowedGrantTypes = GrantTypes.ClientCredentials,
                    //使用密码方式
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                }
            };
        }


        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "123456"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "123456"
                }
            };
        }
    }
}

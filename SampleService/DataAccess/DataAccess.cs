using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SampleService
{
    public class DataAccess : IDataAccess
    {
        private readonly IUnityContainer _container;
        public DataAccess(IUnityContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }
        public IDbConnection InjectedSqlConnection
        {
            get
            { return _container.Resolve<IDbConnection>(); }
        }

        public GetUserAttributesOutput RetrieveUserAttributes(GetUserAttributesInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            GetUserAttributesOutput userAttributesOutput = new GetUserAttributesOutput();
            using (IDbConnection conn = InjectedSqlConnection)
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM UserAttributes WHERE CustomerNo = @CustomerNo";
                    cmd.CommandType = CommandType.Text;
                    IDbDataParameter userIdParam = cmd.CreateParameter();
                    userIdParam.ParameterName = "@CustomerNo";
                    userIdParam.Value = input.CustomerNumber;
                    userIdParam.DbType = DbType.String;
                    cmd.Parameters.Add(userIdParam);
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string startPage = reader.GetString(2);
                            string themeChosen = reader.GetString(3);
                            string memberGreeting = reader.GetString(4);
                            string customerOnboaringstatus = reader.GetString(5);
                            userAttributesOutput.StartPage = startPage;
                            userAttributesOutput.ThemeChosen = themeChosen;
                            userAttributesOutput.MemberGreeting = memberGreeting;
                            userAttributesOutput.CustomerOnboardingStatus = int.Parse(customerOnboaringstatus);
                        }
                    }
                }
                return userAttributesOutput;

            }
        }

        public SetUserAttributesOutput SaveUserAttributes(SetUserAttributesInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            SetUserAttributesOutput output = new SetUserAttributesOutput();
            using (IDbConnection conn = InjectedSqlConnection)
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO UserAttributes (StartPage, ThemeChosen, MemberGreeting, CustomerOnboardingStatus) VALUES (@StartPage, @ThemeChosen, @MemberGreeting, @CustomerOnboardingStatus)";
                    IDbDataParameter startPageParam = cmd.CreateParameter();
                    startPageParam.ParameterName = "@StartPage";
                    startPageParam.Value = input.StartPage;
                    cmd.Parameters.Add(startPageParam);
                    IDbDataParameter themeChosenParam = cmd.CreateParameter();
                    themeChosenParam.ParameterName = "@ThemeChosen";
                    themeChosenParam.Value = input.ThemeChosen;
                    cmd.Parameters.Add(themeChosenParam);
                    IDbDataParameter memberGreetingParam = cmd.CreateParameter();
                    memberGreetingParam.ParameterName = "@MemberGreeting";
                    memberGreetingParam.Value = input.MemberGreeting;
                    cmd.Parameters.Add(memberGreetingParam);
                    IDbDataParameter customerOnboardingStatusParam = cmd.CreateParameter();
                    customerOnboardingStatusParam.ParameterName = "@CustomerOnboardingStatus";
                    customerOnboardingStatusParam.Value = input.CustomerOnboardingStatus;
                    cmd.Parameters.Add(customerOnboardingStatusParam);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        output.Status = 0;
                        
                    }
                    else
                    {
                        output.Status = 1;
                        
                    }
                }
            }
            return output;
        }
    }
}

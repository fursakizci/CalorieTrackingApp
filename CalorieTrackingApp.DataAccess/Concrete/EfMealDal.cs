using CalorieTrackingApp.DataAccess.Abstract;
using CalorieTrackingApp.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.DataAccess.Concrete
{
    public class EfMealDal : EfGenericRepository<Meal, CalorieTrackingContext>, IMealDal
    {
        public void CreateMeal(Meal meal)
        {
            using (var context = new CalorieTrackingContext())
            {
                context.Meals.Add(meal);
                context.SaveChanges();
            }
        }

        public Tuple<List<int>,List<string>> WeeklyData(string userId)
        {

            SqlConnection con = new SqlConnection("Server=DESKTOP-AV372PO\\SQLEXPRESS;Database=CalorieTrackingDb;integrated security=true;");
            con.Open();
            SqlCommand cmdDep = new SqlCommand(@"select sum(f.Calorie),m.DateTime from Meals m inner join Foods f on m.FoodId=f.Id  
            WHERE DateTime BETWEEN DATEADD(DAY, -7, GETDATE()) AND DATEADD(DAY, 1, GETDATE()) AND m.UserId=@UserId group by m.DateTime ", con);
            cmdDep.Parameters.AddWithValue("@UserId", userId);
            SqlDataReader reader = cmdDep.ExecuteReader();

            List<int> calorie = new List<int>();
            List<string> dateTime = new List<string>(); 
            while (reader.Read())
            {
                calorie.Add(reader.GetInt32(0));
                dateTime.Add(reader["DateTime"].ToString());
            }
            con.Close();

            return Tuple.Create(calorie,dateTime);
        }
    }
}

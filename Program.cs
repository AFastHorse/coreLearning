using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            test_mult_insert();
        }
        static void test_mult_insert()
        {
            List<Content> contents = new List<Content>()
            {
                new Content{title="批量插入标题1",content="Contetn1"},
                new Content{title="Mult2",content="Content2" }
            };
            using (var conn = new SqlConnection("server=.;database=CMS;integrated security=true;"))
            {
                string sql = @"Insert into content(title,content,status,add_time,modify_time)
                               values(@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql, contents);
                Console.WriteLine($"test_mult_insert:Insert {result} datas!");
            }
        }
    }
}

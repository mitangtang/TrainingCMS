﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Domain;

namespace Training.Data
{
    public class MovieStore : IMovieStore
    {
        public int AddMovie(Movie movie)
        {
            var sql = string.Format(@"insert into [dbo].[Movie](MovieTypeId,MovieName,Description,Actor,Image,UploadDate,IsAudit) 
                                    values(@MovieTypeId,@MovieName,@Description,@Actor,@Image,@UploadDate,@IsAudit)");
            var parameters = new List<SqlParameter>
           {
               new SqlParameter("@MovieTypeId", movie.MovieTypeId),
               new SqlParameter("@MovieName", movie.MovieName),
               new SqlParameter("@Description", movie.Description),
               new SqlParameter("@Actor", movie.Actor),
               new SqlParameter("@Image", movie.Image),
               new SqlParameter("@UploadDate", movie.UploadDate),
               new SqlParameter("@IsAudit", movie.IsAudit)
           };
            return DBHelper.ExecuteCommand(sql, parameters.ToArray());
        }

        public int UpdateMovie(Movie movie)
        {
            var sql = string.Format(@"UPDATE [dbo].[Movie] SET MovieTypeId=@MovieTypeId,MovieName=@MovieName,Description=@Description,Actor=@Actor,Image=@Image,UploadDate=@UploadDate,IsAudit=@IsAudit WHERE Id=@Id");
            var parameters = new List<SqlParameter>
            { 
               new SqlParameter("@Id",movie.Id),
               new SqlParameter("@MovieTypeId", movie.MovieTypeId),
               new SqlParameter("@MovieName", movie.MovieName),
               new SqlParameter("@Description", movie.Description),
               new SqlParameter("@Actor", movie.Actor),
               new SqlParameter("@Image", movie.Image),
               new SqlParameter("@UploadDate", movie.UploadDate),
               new SqlParameter("@IsAudit", movie.IsAudit)
            };
            return DBHelper.ExecuteCommand(sql, parameters.ToArray());
        }

        public int IsAudit(Movie movie)
        {
            var sql = string.Format(@"UPDATE [dbo].[Movie] SET IsAudit=1 WHERE Id=@Id");
            var parameters = new List<SqlParameter>
            { 
               new SqlParameter("@Id",movie.Id),
            };
            return DBHelper.ExecuteCommand(sql, parameters.ToArray());
        }

        public int DeleteMovie(Movie movie)
        {
            string sql = string.Format(@"DELETE FROM [dbo].[Movie] WHERE (Id=@Id)");
            var parameters = new List<SqlParameter>
            { 
                new SqlParameter("@Id",movie.Id),
            };
            return DBHelper.ExecuteCommand(sql, parameters.ToArray());
        }
        public DataTable ShowMovie(int movieId)
        {
            var sql = string.Format(@"SELECT * FROM [dbo].[Movie] WHERE Id=@Id");
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id",movieId),
            };
            return DBHelper.GetDataSet(sql, parameter.ToArray());
        }
        public DataTable ShowMovie(string movieName)
        {
            var sql = string.Format(@"SELECT * FROM [dbo].[Movie],[dbo].[MovieType] WHERE [dbo].[Movie].MovieTypeId=[dbo].[MovieType].Id and  MovieName LIKE '%" + movieName + "%'");
            //var parameter = new List<SqlParameter>
            //{
            //    new SqlParameter("@MovieName",movieName),
            //};
            //
            return DBHelper.GetDataSet(sql);
        }

        public DataTable UnauditedMovie()
        {
            var sql = string.Format(@"SELECT * FROM [dbo].[Movie],[dbo].[MovieType] WHERE [dbo].[Movie].MovieTypeId=[dbo].[MovieType].Id and IsAudit=0");
            return DBHelper.GetDataSet(sql);
        }

        public DataTable GetMovies()
        {
            var sql = string.Format(@"SELECT * FROM [dbo].[Movie],[dbo].[MovieType] WHERE [dbo].[Movie].MovieTypeId=[dbo].[MovieType].Id");
            return DBHelper.GetDataSet(sql);
        }

        public DataTable GetMovies(string typename, string actor)
        {
            if (typename.Equals("全部"))
            {
                typename = "";
            }
            else
            {
                typename = string.Format(" and MovieTypeId in (select Id from [dbo].[MovieType] where TypeName='{0}')", typename);
            }

            if (!string.IsNullOrEmpty(actor))
            {
                actor = string.Format(" and (Actor like '%{0}%' or MovieName like '{1}')", actor, actor);
            }

            var sql = string.Format(@"select * from [dbo].[Movie] where IsAudit=1 {0}{1} order by UploadDate desc", typename, actor);
            return DBHelper.GetDataSet(sql);
        }
    }
}

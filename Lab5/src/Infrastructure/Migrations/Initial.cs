using System;
using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider)
    {
        return """
               create type UserRole as enum
               (
                   'Admin',
                   'User'
               );
               
               create type OperationResult as enum
               (
                   'Success',
                   'Fail'
               );

               create table users
               (
                   user_id bigint primary key generated always as identity ,
                   user_name text not null ,
                   user_role UserRole not null
               );

               create table accounts
               (
                   account_id bigint primary key generated always as identity ,
                   user_id bigint not null references users(user_id) ,
                   money bigint not null ,
                   account_number text not null ,
                   account_pin text not null 
               );

               create table accounts_operations
               (
                   operation_id bigint primary key generated always as identity ,
                   account_number text not null ,
                   operation text not null ,
                   operation_result OperationResult not null
               );
               """;
    }

    protected override string GetDownSql(IServiceProvider serviceProvider)
    {
        return """
               drop table users;
               drop table accounts;
               drop table accounts_operations;

               drop type UserRole;
               drop type OperationResult;
               """;
    }
}
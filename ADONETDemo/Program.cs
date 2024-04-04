// See https://aka.ms/new-console-template for more information
using System.Data;

Console.WriteLine("Hello, World!");


// приэднаний режим (1С товстий клієнт) 

IDbConnection dbConnection = null;
IDbCommand dbCommand = null;
IDataReader dataReader = null;
IDataRecord dataRecord = null;
IDataParameterCollection dataParameterCollection = null;
IDataParameter dataParameter = null;
IDbTransaction dbTransaction = null;
IsolationLevel isolationLevel = IsolationLevel.ReadCommitted;
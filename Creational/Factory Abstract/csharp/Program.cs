using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            Creater creater = new Creater(new MongoDatabaseFactory());
            creater.CreateCategory();

            Console.Read();
        }
    }

    #region product A
    public abstract class Command
    {
        public abstract void ExecuteCommand(string query);
    }

    public class MsSqlCommand : Command
    {
        public override void ExecuteCommand(string query)
        {
            Console.WriteLine("MsSql query was run.");
        }
    }

    public class MongoCommand : Command
    {
        public override void ExecuteCommand(string query)
        {
            Console.WriteLine("MongoDB query was run.");
        }
    }
    #endregion

    #region product B
    public abstract class Connection
    {
        public abstract bool OpenConnection();
        public abstract bool CloseConnection();
    }

    public class MongoConnection : Connection
    {
        public override bool CloseConnection()
        {
            Console.WriteLine("The connection has been closed.");
            return true;
        }

        public override bool OpenConnection()
        {
            Console.WriteLine("The connection's open.");
            return true;
        }
    }

    public class MsSqlConnection : Connection
    {
        public override bool CloseConnection()
        {
            Console.WriteLine("The connection's closed.");
            return true;
        }

        public override bool OpenConnection()
        {
            Console.WriteLine("The connection's open.");
            return true;
        }
    }
    #endregion

    public abstract class DatabaseFactory
    {
        public abstract Connection CreateConnection();
        public abstract Command CreateCommand();
    }

    public class MongoDatabaseFactory : DatabaseFactory
    {
        public override Connection CreateConnection()
        {
            return new MongoConnection();
        }

        public override Command CreateCommand()
        {
            return new MongoCommand();
        }
    }

    public class MsSqlDatabaseFactory : DatabaseFactory
    {
        public override Connection CreateConnection()
        {
            return new MsSqlConnection();
        }

        public override Command CreateCommand()
        {
            return new MsSqlCommand();
        }
    }

    public class Creater
    {
        private readonly DatabaseFactory _databaseFactory;
        private Connection _connection;
        private Command _command;

        public Creater(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _connection = _databaseFactory.CreateConnection();
            _command = databaseFactory.CreateCommand();
        }

        public void CreateCategory()
        {
            _connection.OpenConnection();
            _command.ExecuteCommand("INSERT..");
            _connection.CloseConnection();
        }
    }
}
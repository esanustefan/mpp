using System;
using System.Collections.Generic;
using System.Data;
using APP_BASCHET.repo;
using baschet.domain;
using log4net;
namespace baschet.repo
{
	public class UserDBRepository: IUserRepository
	{
		private static readonly ILog log = LogManager.GetLogger("UserDbRepository");

		IDictionary<String, string> props;
		public UserDBRepository(IDictionary<String, string> props)
		{
			log.Info("Creating UserDbRepository ");
			this.props = props;
		}
		
		public User findOne(int id)
		{
			log.InfoFormat("Entering findOne with value {0}", id);
			IDbConnection con = DBUtils.getConnection(props);
			
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select id,username,password from Users where id=@id";
				IDbDataParameter paramId = comm.CreateParameter();
				paramId.ParameterName = "@id";
				paramId.Value = id;
				comm.Parameters.Add(paramId);
				
				using (var dataR = comm.ExecuteReader())
				{
					if (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						String username = dataR.GetString(1);
						String password = dataR.GetString(2);
						User user = new User(idV, username, password);
						log.InfoFormat("Exiting findOne with value {0}", user);
						return user;
					}
				}
			}
			log.InfoFormat("Exiting findOne with value {0}", null);
			return null;
		}

		public IEnumerable<User> findAll()
		{
			log.InfoFormat("Entering findAll");
			IDbConnection con = DBUtils.getConnection(props);
			IList<User> tasksR = new List<User>();
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select id,username,password from Users";

				using (var dataR = comm.ExecuteReader())
				{
					while (dataR.Read())
					{
						int idV = dataR.GetInt32(0);
						String username = dataR.GetString(1);
						String password = dataR.GetString(2);
						User user = new User(idV, username, password);
						tasksR.Add(user);
					}
				}
			}
			log.InfoFormat("Exiting findAll with value {0}", tasksR);
			return tasksR;
		}
	
		public User add(User entity)
		{
			log.InfoFormat("Entering add");
			var con = DBUtils.getConnection(props);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "insert into Users(id, username,password) values (@id, @username,@password)";
				var paramId = comm.CreateParameter();
				paramId.ParameterName = "@id";
				paramId.Value = entity.GetId();
				comm.Parameters.Add(paramId);
				
				var paramUsername = comm.CreateParameter();
				paramUsername.ParameterName = "@username";
				paramUsername.Value = entity.Username;
				comm.Parameters.Add(paramUsername);
				var paramPassword = comm.CreateParameter();
				paramPassword.ParameterName = "@password";
				paramPassword.Value = entity.Password;
				comm.Parameters.Add(paramPassword);
				var result = comm.ExecuteNonQuery();
				if (result == 0)
					throw new RepositoryException("No user added !");
			}
			return null;
		}

		public User delete(int id)
		{
			log.InfoFormat("Entering delete with value {0}", id);
			IDbConnection con = DBUtils.getConnection(props);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "delete from Users where id=@id";
				IDbDataParameter paramId = comm.CreateParameter();
				paramId.ParameterName = "@id";
				paramId.Value = id;
				comm.Parameters.Add(paramId);
				var result = comm.ExecuteNonQuery();
				if (result == 0)
					throw new RepositoryException("No user deleted !");
			}
			log.InfoFormat("Exiting delete with value {0}", null);
			return null;
		}

		public void update(User entity)
		{
			throw new NotImplementedException();
		}

		public bool CheckifUserExists(string username, string password)
		{
			IDbConnection con = DBUtils.getConnection(props);
			using (var comm = con.CreateCommand())
			{
				comm.CommandText = "select id,username,password from Users where username=@username and password=@password";
				IDbDataParameter paramUsername = comm.CreateParameter();
				paramUsername.ParameterName = "@username";
				paramUsername.Value = username;
				comm.Parameters.Add(paramUsername);
				IDbDataParameter paramPassword = comm.CreateParameter();
				paramPassword.ParameterName = "@password";
				paramPassword.Value = password;
				comm.Parameters.Add(paramPassword);
				using (var dataR = comm.ExecuteReader())
				{
					if (dataR.Read())
					{
						return true;
					}
				}
			}
			return false;
		}


		// public IEnumerable<SortingTask> findAll()
		// {
		// 	IDbConnection con = DBUtils.getConnection(props);
		// 	IList<SortingTask> tasksR = new List<SortingTask>();
		// 	using (var comm = con.CreateCommand())
		// 	{
		// 		comm.CommandText = "select id,descriere, Elems, orderC, algoritm from SortingTasks";
		//
		// 		using (var dataR = comm.ExecuteReader())
		// 		{
		// 			while (dataR.Read())
		// 			{
		// 				int idV = dataR.GetInt32(0);
		// 				String desc = dataR.GetString(1);
		// 				int elems = dataR.GetInt32(2);
		// 				SortingOrder order = (SortingOrder)Enum.Parse(typeof(SortingOrder), dataR.GetString(3));
		// 				SortingAlgorithm algo = (SortingAlgorithm)Enum.Parse(typeof(SortingAlgorithm), dataR.GetString(4));
		// 				SortingTask task = new SortingTask(idV, desc, elems, order, algo);
		// 				tasksR.Add(task);
		// 			}
		// 		}
		// 	}
		//
		// 	return tasksR;
		// }
		// public void save(SortingTask entity)
		// {
		// 	var con = DBUtils.getConnection(props);
		//
		// 	using (var comm = con.CreateCommand())
		// 	{
		// 		comm.CommandText = "insert into SortingTasks  values (@idT, @desc, @elems, @orderC, @algo)";
		// 		var paramId = comm.CreateParameter();
		// 		paramId.ParameterName = "@idT";
		// 		paramId.Value = entity.Id;
		// 		comm.Parameters.Add(paramId);
		//
		// 		var paramDesc = comm.CreateParameter();
		// 		paramDesc.ParameterName = "@desc";
		// 		paramDesc.Value = entity.Description;
		// 		comm.Parameters.Add(paramDesc);
		//
		// 		var paramElems = comm.CreateParameter();
		// 		paramElems.ParameterName = "@elems";
		// 		paramElems.Value = entity.Elems;
		// 		comm.Parameters.Add(paramElems);
		//
		// 		IDbDataParameter paramOrder = comm.CreateParameter();
		// 		paramOrder.ParameterName = "@orderC";
		// 		paramOrder.Value = entity.Order.ToString();
		// 		comm.Parameters.Add(paramOrder);
		//
		// 		IDbDataParameter paramAlgo = comm.CreateParameter();
		// 		paramAlgo.ParameterName = "@algo";
		// 		paramAlgo.Value = entity.Algorithm.ToString();
		// 		comm.Parameters.Add(paramAlgo);
		//
		// 		var result = comm.ExecuteNonQuery();
		// 		if (result == 0)
		// 			throw new RepositoryException("No task added !");
		// 	}
		// 	
		// }
		// public void delete(int id)
		// {
		// 	IDbConnection con = DBUtils.getConnection(props);
		// 	using (var comm = con.CreateCommand())
		// 	{
		// 		comm.CommandText = "delete from SortingTasks where id=@id";
		// 		IDbDataParameter paramId = comm.CreateParameter();
		// 		paramId.ParameterName = "@id";
		// 		paramId.Value = id;
		// 		comm.Parameters.Add(paramId);
		// 		var dataR = comm.ExecuteNonQuery();
		// 		if (dataR == 0)
		// 			throw new RepositoryException("No task deleted!");
		// 	}
		// }
	}
	
	
}

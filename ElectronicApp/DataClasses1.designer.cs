﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectronicApp
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ElectronicApp_Security")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ElectronicApp_SecurityConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspAlterWebUser")]
		public int uspAlterWebUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> userID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Username", DbType="Text")] string username, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="Text")] string password)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userID, username, password);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspAlterBrokerUser")]
		public int uspAlterBrokerUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> userID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Username", DbType="VarChar(50)")] string username, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="VarChar(50)")] string password)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userID, username, password);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspLoginWebuser")]
		public ISingleResult<uspLoginWebuserResult> uspLoginWebuser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserName", DbType="VarChar(50)")] string userName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="VarChar(50)")] string password)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName, password);
			return ((ISingleResult<uspLoginWebuserResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspCheckUsername")]
		public ISingleResult<uspCheckUsernameResult> uspCheckUsername([global::System.Data.Linq.Mapping.ParameterAttribute(Name="User", DbType="VarChar(50)")] string user)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), user);
			return ((ISingleResult<uspCheckUsernameResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspGetBrokerUserByOwnerID")]
		public ISingleResult<uspGetBrokerUserByOwnerIDResult> uspGetBrokerUserByOwnerID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="OwnerID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> ownerID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ownerID);
			return ((ISingleResult<uspGetBrokerUserByOwnerIDResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspGetWebUserByOwnerID")]
		public ISingleResult<uspGetWebUserByOwnerIDResult> uspGetWebUserByOwnerID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="OwnerID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> ownerID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ownerID);
			return ((ISingleResult<uspGetWebUserByOwnerIDResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspInsertAttachmentData")]
		public int uspInsertAttachmentData([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ObjectID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> objectID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OwnerID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> ownerID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Phrase", DbType="Image")] System.Data.Linq.Binary phrase, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Vector", DbType="Image")] System.Data.Linq.Binary vector)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), objectID, ownerID, phrase, vector);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspInsertWebUser")]
		public int uspInsertWebUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> userID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="OwnerID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> ownerID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Username", DbType="Text")] string username, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="Text")] string password)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userID, ownerID, username, password);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspLogAudit")]
		public int uspLogAudit([global::System.Data.Linq.Mapping.ParameterAttribute(Name="EntryID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> entryID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="EventStatus", DbType="VarChar(50)")] string eventStatus, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="EventDescription", DbType="VarChar(500)")] string eventDescription, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="EventTriggeredBy", DbType="VarChar(50)")] string eventTriggeredBy, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="EventType", DbType="VarChar(50)")] string eventType)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), entryID, eventStatus, eventDescription, eventTriggeredBy, eventType);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspLoginBrokeruser")]
		public ISingleResult<uspLoginBrokeruserResult> uspLoginBrokeruser([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string login, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(200)")] string password)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), login, password);
			return ((ISingleResult<uspLoginBrokeruserResult>)(result.ReturnValue));
		}
	}
	
	public partial class uspLoginWebuserResult
	{
		
		private System.Guid _AssociatedWith;
		
		public uspLoginWebuserResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AssociatedWith", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid AssociatedWith
		{
			get
			{
				return this._AssociatedWith;
			}
			set
			{
				if ((this._AssociatedWith != value))
				{
					this._AssociatedWith = value;
				}
			}
		}
	}
	
	public partial class uspCheckUsernameResult
	{
		
		private System.Guid _UserID;
		
		public uspCheckUsernameResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this._UserID = value;
				}
			}
		}
	}
	
	public partial class uspGetBrokerUserByOwnerIDResult
	{
		
		private System.Guid _UserID;
		
		private System.Guid _AssociatedWith;
		
		private string _UserName;
		
		private string _Password;
		
		private System.DateTime _AddedDate;
		
		public uspGetBrokerUserByOwnerIDResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this._UserID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AssociatedWith", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid AssociatedWith
		{
			get
			{
				return this._AssociatedWith;
			}
			set
			{
				if ((this._AssociatedWith != value))
				{
					this._AssociatedWith = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this._UserName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this._Password = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddedDate", DbType="DateTime NOT NULL")]
		public System.DateTime AddedDate
		{
			get
			{
				return this._AddedDate;
			}
			set
			{
				if ((this._AddedDate != value))
				{
					this._AddedDate = value;
				}
			}
		}
	}
	
	public partial class uspGetWebUserByOwnerIDResult
	{
		
		private System.Guid _UserID;
		
		private System.Guid _AssociatedWith;
		
		private string _UserName;
		
		private string _Password;
		
		private System.DateTime _AddedDate;
		
		private System.DateTime _ValidFrom;
		
		private System.DateTime _ValidTo;
		
		public uspGetWebUserByOwnerIDResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this._UserID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AssociatedWith", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid AssociatedWith
		{
			get
			{
				return this._AssociatedWith;
			}
			set
			{
				if ((this._AssociatedWith != value))
				{
					this._AssociatedWith = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this._UserName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this._Password = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddedDate", DbType="DateTime NOT NULL")]
		public System.DateTime AddedDate
		{
			get
			{
				return this._AddedDate;
			}
			set
			{
				if ((this._AddedDate != value))
				{
					this._AddedDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ValidFrom", DbType="DateTime NOT NULL")]
		public System.DateTime ValidFrom
		{
			get
			{
				return this._ValidFrom;
			}
			set
			{
				if ((this._ValidFrom != value))
				{
					this._ValidFrom = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ValidTo", DbType="DateTime NOT NULL")]
		public System.DateTime ValidTo
		{
			get
			{
				return this._ValidTo;
			}
			set
			{
				if ((this._ValidTo != value))
				{
					this._ValidTo = value;
				}
			}
		}
	}
	
	public partial class uspLoginBrokeruserResult
	{
		
		private System.Guid _associatedWith;
		
		public uspLoginBrokeruserResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_associatedWith", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid associatedWith
		{
			get
			{
				return this._associatedWith;
			}
			set
			{
				if ((this._associatedWith != value))
				{
					this._associatedWith = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
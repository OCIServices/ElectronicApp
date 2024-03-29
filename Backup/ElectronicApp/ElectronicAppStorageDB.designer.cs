﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="ElectronicApp_Storage")]
	public partial class ElectronicAppStorageDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public ElectronicAppStorageDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ElectronicApp_StorageConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ElectronicAppStorageDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ElectronicAppStorageDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ElectronicAppStorageDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ElectronicAppStorageDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[Function(Name="dbo.uspInsertSubmission")]
		public int uspInsertSubmission([Parameter(Name="SubmissionAttachmentID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> submissionAttachmentID, [Parameter(Name="OwnerID", DbType="UniqueIdentifier")] System.Nullable<System.Guid> ownerID, [Parameter(Name="Attachment", DbType="Image")] System.Data.Linq.Binary attachment, [Parameter(Name="FileName", DbType="VarChar(100)")] string fileName, [Parameter(Name="Extension", DbType="VarChar(10)")] string extension, [Parameter(Name="AddedBy", DbType="VarChar(50)")] string addedBy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), submissionAttachmentID, ownerID, attachment, fileName, extension, addedBy);
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.uspInsertBrokerImage")]
		public int uspInsertBrokerImage([Parameter(DbType="UniqueIdentifier")] System.Nullable<System.Guid> attid, [Parameter(DbType="UniqueIdentifier")] System.Nullable<System.Guid> owner, [Parameter(DbType="Image")] System.Data.Linq.Binary att, [Parameter(DbType="VarChar(100)")] string fn, [Parameter(DbType="VarChar(10)")] string ext)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), attid, owner, att, fn, ext);
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.uspDeleteBrokerImageByOwnerID")]
		public int uspDeleteBrokerImageByOwnerID([Parameter(DbType="UniqueIdentifier")] System.Nullable<System.Guid> owner)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), owner);
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.uspGetBrokerImageByOwnerID")]
		public ISingleResult<uspGetBrokerImageByOwnerIDResult> uspGetBrokerImageByOwnerID([Parameter(DbType="UniqueIdentifier")] System.Nullable<System.Guid> owner)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), owner);
			return ((ISingleResult<uspGetBrokerImageByOwnerIDResult>)(result.ReturnValue));
		}
	}
	
	public partial class uspGetBrokerImageByOwnerIDResult
	{
		
		private System.Guid _AttachmentID;
		
		private System.Guid _AssociatedWith;
		
		private System.Data.Linq.Binary _Attachment;
		
		private string _FileName;
		
		private string _Extension;
		
		public uspGetBrokerImageByOwnerIDResult()
		{
		}
		
		[Column(Storage="_AttachmentID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid AttachmentID
		{
			get
			{
				return this._AttachmentID;
			}
			set
			{
				if ((this._AttachmentID != value))
				{
					this._AttachmentID = value;
				}
			}
		}
		
		[Column(Storage="_AssociatedWith", DbType="UniqueIdentifier NOT NULL")]
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
		
		[Column(Storage="_Attachment", DbType="Image NOT NULL", CanBeNull=false)]
		public System.Data.Linq.Binary Attachment
		{
			get
			{
				return this._Attachment;
			}
			set
			{
				if ((this._Attachment != value))
				{
					this._Attachment = value;
				}
			}
		}
		
		[Column(Storage="_FileName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string FileName
		{
			get
			{
				return this._FileName;
			}
			set
			{
				if ((this._FileName != value))
				{
					this._FileName = value;
				}
			}
		}
		
		[Column(Storage="_Extension", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Extension
		{
			get
			{
				return this._Extension;
			}
			set
			{
				if ((this._Extension != value))
				{
					this._Extension = value;
				}
			}
		}
	}
}
#pragma warning restore 1591

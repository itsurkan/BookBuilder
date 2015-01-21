﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication1.DbModels
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="aspnet-MvcApplication1-20141222224613")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDocuments(Documents instance);
    partial void UpdateDocuments(Documents instance);
    partial void DeleteDocuments(Documents instance);
    partial void InsertProjects(Projects instance);
    partial void UpdateProjects(Projects instance);
    partial void DeleteProjects(Projects instance);
    partial void InsertRole(Role instance);
    partial void UpdateRole(Role instance);
    partial void DeleteRole(Role instance);
    partial void InsertSecretQuestion(SecretQuestion instance);
    partial void UpdateSecretQuestion(SecretQuestion instance);
    partial void DeleteSecretQuestion(SecretQuestion instance);
    partial void InsertUserProfile(UserProfile instance);
    partial void UpdateUserProfile(UserProfile instance);
    partial void DeleteUserProfile(UserProfile instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["aspnet_MvcApplication1_20141222224613ConnectionString"].ConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<Documents> Documents
		{
			get
			{
				return this.GetTable<Documents>();
			}
		}
		
		public System.Data.Linq.Table<Projects> Projects
		{
			get
			{
				return this.GetTable<Projects>();
			}
		}
		
		public System.Data.Linq.Table<Role> Roles
		{
			get
			{
				return this.GetTable<Role>();
			}
		}
		
		public System.Data.Linq.Table<SecretQuestion> SecretQuestions
		{
			get
			{
				return this.GetTable<SecretQuestion>();
			}
		}
		
		public System.Data.Linq.Table<UserProfile> UserProfiles
		{
			get
			{
				return this.GetTable<UserProfile>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Documents")]
	public partial class Documents : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Path;
		
		private char _IsInRecycle;
		
		private System.DateTime _Date;
		
		private string _Name;
		
		private int _Project;
		
		private string _Description;
		
		private EntityRef<Projects> _Projects;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPathChanging(string value);
    partial void OnPathChanged();
    partial void OnIsInRecycleChanging(char value);
    partial void OnIsInRecycleChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnProjectChanging(int value);
    partial void OnProjectChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public Documents()
		{
			this._Projects = default(EntityRef<Projects>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Path", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Path
		{
			get
			{
				return this._Path;
			}
			set
			{
				if ((this._Path != value))
				{
					this.OnPathChanging(value);
					this.SendPropertyChanging();
					this._Path = value;
					this.SendPropertyChanged("Path");
					this.OnPathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsInRecycle", DbType="NChar(1) NOT NULL")]
		public char IsInRecycle
		{
			get
			{
				return this._IsInRecycle;
			}
			set
			{
				if ((this._IsInRecycle != value))
				{
					this.OnIsInRecycleChanging(value);
					this.SendPropertyChanging();
					this._IsInRecycle = value;
					this.SendPropertyChanged("IsInRecycle");
					this.OnIsInRecycleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Project", DbType="Int NOT NULL")]
		public int Project
		{
			get
			{
				return this._Project;
			}
			set
			{
				if ((this._Project != value))
				{
					if (this._Projects.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProjectChanging(value);
					this.SendPropertyChanging();
					this._Project = value;
					this.SendPropertyChanged("Project");
					this.OnProjectChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(300)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Project_Document", Storage="_Projects", ThisKey="Project", OtherKey="Id", IsForeignKey=true)]
		public Projects Projects
		{
			get
			{
				return this._Projects.Entity;
			}
			set
			{
				Projects previousValue = this._Projects.Entity;
				if (((previousValue != value) 
							|| (this._Projects.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Projects.Entity = null;
						previousValue.Documents.Remove(this);
					}
					this._Projects.Entity = value;
					if ((value != null))
					{
						value.Documents.Add(this);
						this._Project = value.Id;
					}
					else
					{
						this._Project = default(int);
					}
					this.SendPropertyChanged("Projects");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Projects")]
	public partial class Projects : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Description;
		
		private string _Title;
		
		private string _UserLogin;
		
		private string _Path;
		
		private System.DateTime _Date;
		
		private System.Xml.Linq.XElement _Settings;
		
		private EntitySet<Documents> _Documents;
		
		private EntityRef<UserProfile> _UserProfile;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnUserLoginChanging(string value);
    partial void OnUserLoginChanged();
    partial void OnPathChanging(string value);
    partial void OnPathChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnSettingsChanging(System.Xml.Linq.XElement value);
    partial void OnSettingsChanged();
    #endregion
		
		public Projects()
		{
			this._Documents = new EntitySet<Documents>(new Action<Documents>(this.attach_Documents), new Action<Documents>(this.detach_Documents));
			this._UserProfile = default(EntityRef<UserProfile>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserLogin", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string UserLogin
		{
			get
			{
				return this._UserLogin;
			}
			set
			{
				if ((this._UserLogin != value))
				{
					if (this._UserProfile.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserLoginChanging(value);
					this.SendPropertyChanging();
					this._UserLogin = value;
					this.SendPropertyChanged("UserLogin");
					this.OnUserLoginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Path", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Path
		{
			get
			{
				return this._Path;
			}
			set
			{
				if ((this._Path != value))
				{
					this.OnPathChanging(value);
					this.SendPropertyChanging();
					this._Path = value;
					this.SendPropertyChanged("Path");
					this.OnPathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Settings", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
		public System.Xml.Linq.XElement Settings
		{
			get
			{
				return this._Settings;
			}
			set
			{
				if ((this._Settings != value))
				{
					this.OnSettingsChanging(value);
					this.SendPropertyChanging();
					this._Settings = value;
					this.SendPropertyChanged("Settings");
					this.OnSettingsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Project_Document", Storage="_Documents", ThisKey="Id", OtherKey="Project")]
		public EntitySet<Documents> Documents
		{
			get
			{
				return this._Documents;
			}
			set
			{
				this._Documents.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserProfile_Project", Storage="_UserProfile", ThisKey="UserLogin", OtherKey="Login", IsForeignKey=true)]
		public UserProfile UserProfile
		{
			get
			{
				return this._UserProfile.Entity;
			}
			set
			{
				UserProfile previousValue = this._UserProfile.Entity;
				if (((previousValue != value) 
							|| (this._UserProfile.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._UserProfile.Entity = null;
						previousValue.Projects.Remove(this);
					}
					this._UserProfile.Entity = value;
					if ((value != null))
					{
						value.Projects.Add(this);
						this._UserLogin = value.Login;
					}
					else
					{
						this._UserLogin = default(string);
					}
					this.SendPropertyChanged("UserProfile");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Documents(Documents entity)
		{
			this.SendPropertyChanging();
			entity.Projects = this;
		}
		
		private void detach_Documents(Documents entity)
		{
			this.SendPropertyChanging();
			entity.Projects = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Roles")]
	public partial class Role : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _PriorityLevel;
		
		private string _LevelName;
		
		private EntitySet<UserProfile> _UserProfiles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPriorityLevelChanging(int value);
    partial void OnPriorityLevelChanged();
    partial void OnLevelNameChanging(string value);
    partial void OnLevelNameChanged();
    #endregion
		
		public Role()
		{
			this._UserProfiles = new EntitySet<UserProfile>(new Action<UserProfile>(this.attach_UserProfiles), new Action<UserProfile>(this.detach_UserProfiles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PriorityLevel", DbType="Int NOT NULL")]
		public int PriorityLevel
		{
			get
			{
				return this._PriorityLevel;
			}
			set
			{
				if ((this._PriorityLevel != value))
				{
					this.OnPriorityLevelChanging(value);
					this.SendPropertyChanging();
					this._PriorityLevel = value;
					this.SendPropertyChanged("PriorityLevel");
					this.OnPriorityLevelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LevelName", DbType="NChar(20)")]
		public string LevelName
		{
			get
			{
				return this._LevelName;
			}
			set
			{
				if ((this._LevelName != value))
				{
					this.OnLevelNameChanging(value);
					this.SendPropertyChanging();
					this._LevelName = value;
					this.SendPropertyChanged("LevelName");
					this.OnLevelNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Role_UserProfile", Storage="_UserProfiles", ThisKey="Id", OtherKey="Role")]
		public EntitySet<UserProfile> UserProfiles
		{
			get
			{
				return this._UserProfiles;
			}
			set
			{
				this._UserProfiles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_UserProfiles(UserProfile entity)
		{
			this.SendPropertyChanging();
			entity.Role1 = this;
		}
		
		private void detach_UserProfiles(UserProfile entity)
		{
			this.SendPropertyChanging();
			entity.Role1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SecretQuestions")]
	public partial class SecretQuestion : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Question;
		
		private EntitySet<UserProfile> _UserProfiles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnQuestionChanging(string value);
    partial void OnQuestionChanged();
    #endregion
		
		public SecretQuestion()
		{
			this._UserProfiles = new EntitySet<UserProfile>(new Action<UserProfile>(this.attach_UserProfiles), new Action<UserProfile>(this.detach_UserProfiles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Question", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string Question
		{
			get
			{
				return this._Question;
			}
			set
			{
				if ((this._Question != value))
				{
					this.OnQuestionChanging(value);
					this.SendPropertyChanging();
					this._Question = value;
					this.SendPropertyChanged("Question");
					this.OnQuestionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SecretQuestion_UserProfile", Storage="_UserProfiles", ThisKey="Id", OtherKey="SecretQuestion")]
		public EntitySet<UserProfile> UserProfiles
		{
			get
			{
				return this._UserProfiles;
			}
			set
			{
				this._UserProfiles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_UserProfiles(UserProfile entity)
		{
			this.SendPropertyChanging();
			entity.SecretQuestion1 = this;
		}
		
		private void detach_UserProfiles(UserProfile entity)
		{
			this.SendPropertyChanging();
			entity.SecretQuestion1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserProfile")]
	public partial class UserProfile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Login;
		
		private string _Mail;
		
		private string _Password;
		
		private System.Nullable<int> _SecretQuestion;
		
		private string _SecretAnswer;
		
		private System.Nullable<System.DateTime> _Age;
		
		private string _FullName;
		
		private int _Role;
		
		private System.Data.Linq.Binary _Avatar;
		
		private EntitySet<Projects> _Projects;
		
		private EntityRef<SecretQuestion> _SecretQuestion1;
		
		private EntityRef<Role> _Role1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLoginChanging(string value);
    partial void OnLoginChanged();
    partial void OnMailChanging(string value);
    partial void OnMailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnSecretQuestionChanging(System.Nullable<int> value);
    partial void OnSecretQuestionChanged();
    partial void OnSecretAnswerChanging(string value);
    partial void OnSecretAnswerChanged();
    partial void OnAgeChanging(System.Nullable<System.DateTime> value);
    partial void OnAgeChanged();
    partial void OnFullNameChanging(string value);
    partial void OnFullNameChanged();
    partial void OnRoleChanging(int value);
    partial void OnRoleChanged();
    partial void OnAvatarChanging(System.Data.Linq.Binary value);
    partial void OnAvatarChanged();
    #endregion
		
		public UserProfile()
		{
			this._Projects = new EntitySet<Projects>(new Action<Projects>(this.attach_Projects), new Action<Projects>(this.detach_Projects));
			this._SecretQuestion1 = default(EntityRef<SecretQuestion>);
			this._Role1 = default(EntityRef<Role>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Login", DbType="NVarChar(30) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Login
		{
			get
			{
				return this._Login;
			}
			set
			{
				if ((this._Login != value))
				{
					this.OnLoginChanging(value);
					this.SendPropertyChanging();
					this._Login = value;
					this.SendPropertyChanged("Login");
					this.OnLoginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Mail", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Mail
		{
			get
			{
				return this._Mail;
			}
			set
			{
				if ((this._Mail != value))
				{
					this.OnMailChanging(value);
					this.SendPropertyChanging();
					this._Mail = value;
					this.SendPropertyChanged("Mail");
					this.OnMailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
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
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SecretQuestion", DbType="Int")]
		public System.Nullable<int> SecretQuestion
		{
			get
			{
				return this._SecretQuestion;
			}
			set
			{
				if ((this._SecretQuestion != value))
				{
					if (this._SecretQuestion1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSecretQuestionChanging(value);
					this.SendPropertyChanging();
					this._SecretQuestion = value;
					this.SendPropertyChanged("SecretQuestion");
					this.OnSecretQuestionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SecretAnswer", DbType="NVarChar(30)")]
		public string SecretAnswer
		{
			get
			{
				return this._SecretAnswer;
			}
			set
			{
				if ((this._SecretAnswer != value))
				{
					this.OnSecretAnswerChanging(value);
					this.SendPropertyChanging();
					this._SecretAnswer = value;
					this.SendPropertyChanged("SecretAnswer");
					this.OnSecretAnswerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="DateTime")]
		public System.Nullable<System.DateTime> Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this.OnAgeChanging(value);
					this.SendPropertyChanging();
					this._Age = value;
					this.SendPropertyChanged("Age");
					this.OnAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullName", DbType="NVarChar(40)")]
		public string FullName
		{
			get
			{
				return this._FullName;
			}
			set
			{
				if ((this._FullName != value))
				{
					this.OnFullNameChanging(value);
					this.SendPropertyChanging();
					this._FullName = value;
					this.SendPropertyChanged("FullName");
					this.OnFullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Role", DbType="Int NOT NULL")]
		public int Role
		{
			get
			{
				return this._Role;
			}
			set
			{
				if ((this._Role != value))
				{
					if (this._Role1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRoleChanging(value);
					this.SendPropertyChanging();
					this._Role = value;
					this.SendPropertyChanged("Role");
					this.OnRoleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Avatar", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Avatar
		{
			get
			{
				return this._Avatar;
			}
			set
			{
				if ((this._Avatar != value))
				{
					this.OnAvatarChanging(value);
					this.SendPropertyChanging();
					this._Avatar = value;
					this.SendPropertyChanged("Avatar");
					this.OnAvatarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserProfile_Project", Storage="_Projects", ThisKey="Login", OtherKey="UserLogin")]
		public EntitySet<Projects> Projects
		{
			get
			{
				return this._Projects;
			}
			set
			{
				this._Projects.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SecretQuestion_UserProfile", Storage="_SecretQuestion1", ThisKey="SecretQuestion", OtherKey="Id", IsForeignKey=true)]
		public SecretQuestion SecretQuestion1
		{
			get
			{
				return this._SecretQuestion1.Entity;
			}
			set
			{
				SecretQuestion previousValue = this._SecretQuestion1.Entity;
				if (((previousValue != value) 
							|| (this._SecretQuestion1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._SecretQuestion1.Entity = null;
						previousValue.UserProfiles.Remove(this);
					}
					this._SecretQuestion1.Entity = value;
					if ((value != null))
					{
						value.UserProfiles.Add(this);
						this._SecretQuestion = value.Id;
					}
					else
					{
						this._SecretQuestion = default(Nullable<int>);
					}
					this.SendPropertyChanged("SecretQuestion1");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Role_UserProfile", Storage="_Role1", ThisKey="Role", OtherKey="Id", IsForeignKey=true)]
		public Role Role1
		{
			get
			{
				return this._Role1.Entity;
			}
			set
			{
				Role previousValue = this._Role1.Entity;
				if (((previousValue != value) 
							|| (this._Role1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Role1.Entity = null;
						previousValue.UserProfiles.Remove(this);
					}
					this._Role1.Entity = value;
					if ((value != null))
					{
						value.UserProfiles.Add(this);
						this._Role = value.Id;
					}
					else
					{
						this._Role = default(int);
					}
					this.SendPropertyChanged("Role1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Projects(Projects entity)
		{
			this.SendPropertyChanging();
			entity.UserProfile = this;
		}
		
		private void detach_Projects(Projects entity)
		{
			this.SendPropertyChanging();
			entity.UserProfile = null;
		}
	}
}
#pragma warning restore 1591
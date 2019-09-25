﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MailSender.Lib.Data.Linq2SQL
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MailSenderDB")]
	public partial class MailSenderDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertServer_smtp(Server_smtp instance);
    partial void UpdateServer_smtp(Server_smtp instance);
    partial void DeleteServer_smtp(Server_smtp instance);
    partial void InsertRecipient(Recipient instance);
    partial void UpdateRecipient(Recipient instance);
    partial void DeleteRecipient(Recipient instance);
    #endregion
		
		public MailSenderDBDataContext() : 
				base(global::MailSender.Lib.Properties.Settings.Default.MailSenderDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MailSenderDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MailSenderDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MailSenderDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MailSenderDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Server_smtp> Server_smtp
		{
			get
			{
				return this.GetTable<Server_smtp>();
			}
		}
		
		public System.Data.Linq.Table<Sender> Sender
		{
			get
			{
				return this.GetTable<Sender>();
			}
		}
		
		public System.Data.Linq.Table<Recipient> Recipient
		{
			get
			{
				return this.GetTable<Recipient>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Server_smtp")]
	public partial class Server_smtp : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _server_id;
		
		private string _address;
		
		private int _port;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onserver_idChanging(int value);
    partial void Onserver_idChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OnportChanging(int value);
    partial void OnportChanged();
    #endregion
		
		public Server_smtp()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_server_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int server_id
		{
			get
			{
				return this._server_id;
			}
			set
			{
				if ((this._server_id != value))
				{
					this.Onserver_idChanging(value);
					this.SendPropertyChanging();
					this._server_id = value;
					this.SendPropertyChanged("server_id");
					this.Onserver_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="VarChar(25) NOT NULL", CanBeNull=false)]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_port", DbType="Int NOT NULL")]
		public int port
		{
			get
			{
				return this._port;
			}
			set
			{
				if ((this._port != value))
				{
					this.OnportChanging(value);
					this.SendPropertyChanging();
					this._port = value;
					this.SendPropertyChanged("port");
					this.OnportChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.v_sender")]
	public partial class Sender
	{
		
		private int _sender_id;
		
		private string _login;
		
		private string _password;
		
		private string _email;
		
		private System.Nullable<int> _server_server_id;
		
		private string _smtp_address;
		
		private int _smtp_port;
		
		public Sender()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sender_id", DbType="Int NOT NULL")]
		public int sender_id
		{
			get
			{
				return this._sender_id;
			}
			set
			{
				if ((this._sender_id != value))
				{
					this._sender_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_login", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string login
		{
			get
			{
				return this._login;
			}
			set
			{
				if ((this._login != value))
				{
					this._login = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this._password = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(255)")]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this._email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_server_server_id", DbType="Int")]
		public System.Nullable<int> server_server_id
		{
			get
			{
				return this._server_server_id;
			}
			set
			{
				if ((this._server_server_id != value))
				{
					this._server_server_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_smtp_address", DbType="VarChar(25) NOT NULL", CanBeNull=false)]
		public string smtp_address
		{
			get
			{
				return this._smtp_address;
			}
			set
			{
				if ((this._smtp_address != value))
				{
					this._smtp_address = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_smtp_port", DbType="Int NOT NULL")]
		public int smtp_port
		{
			get
			{
				return this._smtp_port;
			}
			set
			{
				if ((this._smtp_port != value))
				{
					this._smtp_port = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Recipient")]
	public partial class Recipient : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _recipient_id;
		
		private string _name;
		
		private string _email;
		
		private string _description;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onrecipient_idChanging(int value);
    partial void Onrecipient_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    #endregion
		
		public Recipient()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_recipient_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int recipient_id
		{
			get
			{
				return this._recipient_id;
			}
			set
			{
				if ((this._recipient_id != value))
				{
					this.Onrecipient_idChanging(value);
					this.SendPropertyChanging();
					this._recipient_id = value;
					this.SendPropertyChanged("recipient_id");
					this.Onrecipient_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="VarChar(255)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
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
}
#pragma warning restore 1591
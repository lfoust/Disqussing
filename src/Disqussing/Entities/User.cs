namespace Disqussing
{
	using System;
	using Newtonsoft.Json;

	public class User : Entity
	{
		private string username;
		[JsonProperty("username")]
		public string UserName
		{
			get { return username; }
			set { username = value; NotifyOfPropertyChange(() => UserName); }
		}

		private int numFollowers;
		[JsonProperty("numFollowers")]
		public int NumFollowers
		{
			get { return numFollowers; }
			set { numFollowers = value; NotifyOfPropertyChange(() => NumFollowers); }
		}

		private string about;
		[JsonProperty("about")]
		public string About
		{
			get { return about; }
			set { about = value; NotifyOfPropertyChange(() => About); }
		}

		private string name;
		[JsonProperty("name")]
		public string Name
		{
			get { return name; }
			set { name = value; NotifyOfPropertyChange(() => Name); }
		}

		private int numPosts;
		[JsonProperty("numPosts")]
		public int NumPosts
		{
			get { return numPosts; }
			set { numPosts = value; NotifyOfPropertyChange(() => NumPosts); }
		}

		private string url;
		[JsonProperty("url")]
		public string Url
		{
			get { return url; }
			set { url = value; NotifyOfPropertyChange(() => Url); }
		}

		private bool isAnonymous;
		[JsonProperty("isAnonymous")]
		public bool IsAnonymous
		{
			get { return isAnonymous; }
			set { isAnonymous = value; NotifyOfPropertyChange(() => IsAnonymous); }
		}

		private int numFollowing;
		[JsonProperty("numFollowing")]
		public int NumFollowing
		{
			get { return numFollowing; }
			set { numFollowing = value; NotifyOfPropertyChange(() => NumFollowing); }
		}

		private Connections connections;
		[JsonProperty("connections")]
		public Connections Connections
		{
			get { return connections; }
			set { connections = value; NotifyOfPropertyChange(() => Connections); }
		}

		private string emailHash;
		[JsonProperty("emailHash")]
		public string EmailHash
		{
			get { return emailHash; }
			set { emailHash = value; NotifyOfPropertyChange(() => EmailHash); }
		}

		private string location;
		[JsonProperty("location")]
		public string Location
		{
			get { return location; }
			set { location = value; NotifyOfPropertyChange(() => Location); }
		}

		private string profileUrl;
		[JsonProperty("profileUrl")]
		public string ProfileUrl
		{
			get { return profileUrl; }
			set { profileUrl = value; NotifyOfPropertyChange(() => ProfileUrl); }
		}

		private int numLikesReceived;
		[JsonProperty("numLikesReceived")]
		public int NumLikesReceived
		{
			get { return numLikesReceived; }
			set { numLikesReceived = value; NotifyOfPropertyChange(() => NumLikesReceived); }
		}

		private bool isPrimary;
		[JsonProperty("isPrimary")]
		public bool IsPrimary
		{
			get { return isPrimary; }
			set { isPrimary = value; NotifyOfPropertyChange(() => IsPrimary); }
		}

		private DateTime joinedAt;
		[JsonProperty("joinedAt")]
		public DateTime JoinedAt
		{
			get { return joinedAt; }
			set { joinedAt = value; NotifyOfPropertyChange(() => JoinedAt); }
		}

		private string id;
		[JsonProperty("id")]
		public string Id
		{
			get { return id; }
			set { id = value; NotifyOfPropertyChange(() => Id); }
		}

		private Avatar avatar;
		[JsonProperty("avatar")]
		public Avatar Avatar
		{
			get { return avatar; }
			set { avatar = value; NotifyOfPropertyChange(() => Avatar); }
		}
	}
}

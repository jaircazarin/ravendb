//-----------------------------------------------------------------------
// <copyright file="ReuseQuery.cs" company="Hibernating Rhinos LTD">
//     Copyright (c) Hibernating Rhinos LTD. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using Raven.Client;
using Xunit;
using System.Linq;

namespace Raven.Tests.Bugs
{
	public class ReuseQuery : LocalClientTest
	{
		[Fact]
		public void CanReuseQuery()
		{
			using(var store = NewDocumentStore())
			{
				using(var session = store.OpenSession())
				{
					var query = session.Query<object>(RavenExtensions.RavenDocumentByEntityName);

					query.Count();
					query.ToList();
				}
			}
		}
	}
}

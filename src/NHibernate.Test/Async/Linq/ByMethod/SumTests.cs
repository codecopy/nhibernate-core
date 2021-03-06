﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Linq;
using NUnit.Framework;
using NHibernate.Linq;

namespace NHibernate.Test.Linq.ByMethod
{
	using System.Threading.Tasks;
	[TestFixture]
	public class SumTestsAsync : LinqTestCase
	{
		[Test]
		public void EmptySumDecimalAsync()
		{
			Assert.That(
				() =>
				{
					return db.OrderLines.Where(ol => false).SumAsync(ol => ol.Discount);
				},
				// Before NH-3850
				Throws.InstanceOf<HibernateException>()
				// After NH-3850
				.Or.InstanceOf<InvalidOperationException>());
		}

		[Test]
		public async Task EmptySumCastNullableDecimalAsync()
		{
			decimal total = await (db.OrderLines.Where(ol => false).SumAsync(ol => (decimal?)ol.Discount)) ?? 0;
			Assert.AreEqual(0, total);
		}

		[Test]
		public async Task SumDecimalAsync()
		{
			decimal total = await (db.OrderLines.SumAsync(ol => ol.Discount));
			Assert.Greater(total, 0);
		}

		[Test]
		public async Task EmptySumNullableDecimalAsync()
		{
			decimal total = await (db.Orders.Where(ol => false).SumAsync(ol => ol.Freight)) ?? 0;
			Assert.AreEqual(0, total);
		}

		[Test]
		public async Task SumNullableDecimalAsync()
		{
			decimal? total = await (db.Orders.SumAsync(ol => ol.Freight));
			Assert.Greater(total, 0);
		}

		[Test]
		public async Task SumSingleAsync()
		{
			float total = await (db.Products.SumAsync(p => p.ShippingWeight));
			Assert.Greater(total, 0);
		}
	}
}

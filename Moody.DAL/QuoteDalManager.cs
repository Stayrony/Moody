// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuoteDalManager.cs" company="">
//   
// </copyright>
// <summary>
//   The quote dal manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moody.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using Moody.DAL.Utility;
    using Moody.Service.Domain;

    /// <summary>
    /// The quote dal manager.
    /// </summary>
    public class QuoteDalManager
    {
        /// <summary>
        /// The sql data manager.
        /// </summary>
        private readonly SqlDataManager sqlDataManager;

        /// <summary>
        /// The table name.
        /// </summary>
        private readonly string tableName = "Quotes";

        /// <summary>
        /// The tag dal manager.
        /// </summary>
        private readonly TagDalManager tagDalManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteDalManager"/> class.
        /// </summary>
        public QuoteDalManager()
        {
            this.sqlDataManager = new SqlDataManager();
            this.tagDalManager = new TagDalManager();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Quote> GetAll()
        {
            var quotes = new List<Quote>();
            var query = "SELECT * FROM " + this.tableName;
            var dataTable = this.sqlDataManager.ExecuteSelectAllQuery(query);


            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Quote quote = new Quote();
                    DateTime date;
                    int quoteId;

                    quoteId = int.Parse(dataRow["QuoteId"].ToString());
                    quote.Author = dataRow["Author"].ToString();
                    quote.Body = dataRow["Body"].ToString();
                    DateTime.TryParse(dataRow["TimeCreated"].ToString(), out date);
                    quote.TimeCreated = date;
                    quote.Tags = this.GetTagsByQuoteId(quoteId);

                    // TODO add list tags

                    quotes.Add(quote);
                }
            }
            else
            {
                return null;
            }

            return quotes;
        }

        /// <summary>
        /// The get tags.
        /// </summary>
        /// <param name="quoteId">
        /// The quote id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> GetTagsByQuoteId(int quoteId)
        {
            List<string> tags = new List<string>();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@QuoteId", SqlDbType.Int) { Value = quoteId };
            DataTable dataTable = this.sqlDataManager.SelectProcedure("GetTagByQuoteId", sqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    tags.Add(dataRow["Name"].ToString());
                }
            }

            return tags;
        }

        /// <summary>
        /// The add new quote.
        /// </summary>
        /// <param name="newQuote"></param>
        /// <returns>
        /// The <see cref="Quote"/>.
        /// </returns>
        public Quote AddNewQuote(Quote newQuote)
        {
            //TODO how to ckeck success or not add

            int quoteId;
            SqlParameter[] sqlParameter = new SqlParameter[3];

            sqlParameter[0] = new SqlParameter("@Author", SqlDbType.VarChar) { Value = newQuote.Author };
            sqlParameter[1] = new SqlParameter("@Body", SqlDbType.Text) { Value = newQuote.Body };
            sqlParameter[2] = new SqlParameter("@TimeCreated", SqlDbType.DateTime) { Value = newQuote.TimeCreated.ToString("yyyy-MM-dd")};

            // TODO add tags

            try
            {
                quoteId = this.sqlDataManager.InsertProcedureWithOutputInsertedId("AddQuote", sqlParameter);

            }
            catch (Exception exception)
            {
                throw exception;
            }

            foreach (var tag in newQuote.Tags)
            {
                var tagId = this.tagDalManager.GetTagIdByName(tag);
               // Array.Clear(sqlParameter, 0, sqlParameter.Length);
               SqlParameter [] sqlTagParameter = new SqlParameter[2];
                sqlTagParameter[0] = new SqlParameter("@QuoteId", SqlDbType.Int) { Value = quoteId };
                sqlTagParameter[1] = new SqlParameter("@TagId", SqlDbType.Int) { Value = tagId };
                this.sqlDataManager.InsertProcedure("BindingQuoteWithTag", sqlTagParameter);
            }

            return newQuote;
        }

        /// <summary>
        /// The get quotes by tag.
        /// </summary>
        /// <param name="tagName">
        /// The tag name.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Quote> GetQuotesByTag(string tagName)
        {
            var quotes = new List<Quote>();
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = tagName };

            var dataTable = this.sqlDataManager.SelectProcedure("GetQuoteByTag", sqlParameter);


            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Quote quote = new Quote();
                    DateTime date;
                    int quoteId;

                    quoteId = int.Parse(dataRow["QuoteId"].ToString());
                    quote.Author = dataRow["Author"].ToString();
                    quote.Body = dataRow["Body"].ToString();
                    DateTime.TryParse(dataRow["TimeCreated"].ToString(), out date);
                    quote.TimeCreated = date;
                    quote.Tags = this.GetTagsByQuoteId(quoteId);

                    // TODO add list tags

                    quotes.Add(quote);
                }
            }
            else
            {
                return null;
            }

            return quotes;
        }

        /// <summary>
        /// The delete quote.
        /// </summary>
        /// <param name="deletingQuote">
        /// The deleting quote.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int DeleteQuote(Quote deletingQuote)
        {
            // TODO delete quote
            return 0;
        }
    }

}
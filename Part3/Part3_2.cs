public DataTable GetCustomerInfo(string id, string startDate = null, string endDate = null)
{
    var dt = new DataTable();
    using (var conn = new SqlConnection("..."))
    {
        conn.Open();

        var sql = "SELECT * FROM Customer WHERE id = '" + id + "'";

        if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
        {
            sql += $" AND created_at >= '{startDate}' AND created_at <= '{endDate}'";
        }

        using (var da = new SqlDataAdapter(sql, conn))
        {
            da.Fill(dt);
        }
    }
    return dt;
}

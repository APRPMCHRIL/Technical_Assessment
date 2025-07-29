public DataTable GetCustomerInfo(string id)

{
    var dt = new DataTable();
    using (var conn = new SqlConnection("...")) // Connection string is hardcoded
    {
        conn.Open();
        var sql = "SELECT * FROM Customer WHERE id = '" + id + "'"; //Sql injection
        using (var da = new SqlDataAdapter(sql, conn))
        {
            da.Fill(dt);
        }
    }
    return dt;
}

//------------------------------------------------------------------
//Task

/*1. In your own words, what is the primary purpose of this function?

    Ans จุดประสงค์ของฟังก์ชัน คือ การใช้ SQL ในการดึงข้อมูล column ทั้งหมดจากตาราง Customer (ลูกค้า) 
        ในฐานข้อมูล โดยใช้ id ในการเป็นตัวกำหนด และคืนค่าเป็น DataTable

*/

/*2. Identify at least three distinct problems with this implementation. Consider aspects such as security, maintainability, and performance.

    Ans 1. SQL Injection เนื่องจากโค้ดนี้ 
            var sql = "SELECT * FROM Customer WHERE id = '" + id + "'";
        การใช้ + เพื่อเชื่อมต่อค่าใน SQL query อาจทำให้เกิดช่องโหว่ SQL Injection

        2. การใช้ SELECT * ทำให้ข้อมูลทั้งหมดถูกดึงออกมา อาจทำให้โหลดข้อมูลมากเกินไป และบางข้อมูลไม่จำเป็น
        แก้โดยการเลือกเฉพาะ column ที่ต้องการเท่านั้น

        3. การใช้ hardcoded กับ Connection string
            using (var conn = new SqlConnection("..."))
        ตรงนี้ทำให้เกิด Security Risk ถ้ามีผู้ไม่หวังดีเข้าถึง source code ก็จะเห็น server database หรือ password ได้
        และยังยากต่อการเปลียนแปลงตัว หากเปลี่ยน database ใหม่ ก็จะต้องมาเปลี่ยนตรง hardcode ทั้งหมด เป็นการเพิ่มความเสี่ยงในการลืมหรือแก้ไขผิดจุด
        แก้ไขโดยการ ใช้ config	เช่น appsettings.json, web.config, .env หรือ ใช้ environment variables แทน
*/

/*3. For each problem identified, briefly propose a specific improvement.

    Ans 1.แก้ Sql Injection แก้โดยการใช้ parameterized query เพื่อให้ฐานข้อมูลจัดการการแทนค่าเอง
        2.แก้การดึงข้อมูลมามากเกินไปโดยการเลือกเฉพาะ column ที่ต้องการเท่านั้น SELECT name, email
        3.แก้การใช้ hardcoded กับ Connection string โดยการ ใช้ config	เช่น appsettings.json, web.config, .env หรือ ใช้ environment variables แทน
*/
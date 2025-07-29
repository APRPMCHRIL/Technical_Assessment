import sqlite3

def get_customer_info(customer_id, startDate=None, endDate=None):
        query = "SELECT id, name, email FROM Customer WHERE id = ?"
        params = [customer_id]

        if startDate and endDate:
            query += " AND created_at >= ? AND created_at <= ?"
            params.extend([startDate, endDate])
            
        with sqlite3.connect('database.db') as conn:
            cursor = conn.cursor()
            cursor.execute(query, params)
            result = cursor.fetchall()
            
        return result

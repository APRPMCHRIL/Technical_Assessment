import sqlite3

def get_customer_info(customer_id):
        query = "SELECT name, email FROM Customer WHERE id = ?"
        params = [customer_id]

        with sqlite3.connect('database.db') as conn:
            cursor = conn.cursor()
            cursor.execute(query, params)
            result = cursor.fetchall()
            
        return result

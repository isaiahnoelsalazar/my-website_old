import sqlite3

class EasySQL:
    def createTable(self, dbname: str, table_name: str, columns: list):
        connection = sqlite3.connect(dbname + ".db")
        sql_query = "CREATE TABLE IF NOT EXISTS " + table_name + "("
        for a in columns:
            column: dict = a
            sql_query += list(column.keys())[0] + " " + list(column.values())[0] + ", "
        sql_query = sql_query[:-2] + ")"
        connection.cursor().execute(sql_query)
        connection.commit()

    def printTable(self, dbname: str, table_name: str):
        connection = sqlite3.connect(dbname + ".db")
        print(connection.cursor().execute("SELECT * FROM " + table_name).fetchall())

    def getTableValues(self, dbname: str, table_name: str):
        connection = sqlite3.connect(dbname + ".db")
        return connection.cursor().execute("SELECT * FROM " + table_name).fetchall()

    def insertToTable(self, dbname: str, table_name: str, values: list):
        connection = sqlite3.connect(dbname + ".db")
        sql_query = "INSERT INTO " + table_name + "("
        for a in values:
            value: dict = a
            sql_query += list(value.keys())[0] + ", "
        sql_query = sql_query[:-2] + ") VALUES ("
        for a in values:
            value: dict = a
            sql_query += "'" + list(value.values())[0] + "', "
        sql_query = sql_query[:-2] + ")"
        connection.cursor().execute(sql_query)
        connection.commit()

'''
How to use:
from easy_sql import EasySQL # Import the class

a = EasySQL() # Create an instance of the class

columns = [{"fname": "text"}, {"lname": "text"}] # Define the columns for the table

a.createTable("sample", "sampletable", columns) # Create specified table

values = [{"fname": "Isaiah"}, {"lname": "Salazar"}] # Define the values to be inserted

a.insertToTable("sample", "sampletable", values) # Insert the values into specified table

print(a.getTableValues("sample", "sampletable")) # Print the values in specified table
'''
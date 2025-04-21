import execute_func

a = execute_func.executeFunc("""
result = ""
session["logged_in"] = "no"
session["uid"] = "-1"
result = "Success"
""")
print(a["result"])

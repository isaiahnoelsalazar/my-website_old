def executeFunc(str):
    local = {}
    exec(str, globals(), local)
    return local
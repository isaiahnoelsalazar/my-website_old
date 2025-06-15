"""
This single endpoint handles the signaling.
- Sharer POSTs its 'offer'.
- Viewer GETs the 'offer'.
- Viewer POSTs its 'answer'.
- Sharer GETs the 'answer'.
"""
result = ""

if session_id not in SESSIONS:
    abort(404, "Session not found.")

session = SESSIONS[session_id]

if request.method == 'POST':
    data = request.json
    if data['type'] == 'offer':
        print(f"Session {session_id}: Received offer.")
        session['offer'] = data
    elif data['type'] == 'answer':
        print(f"Session {session_id}: Received answer.")
        session['answer'] = data
    result = jsonify({"status": "ok"})
elif request.method == 'GET':
    # This is a simple polling GET. The client will ask for 'offer' or 'answer'.
    sdp_type = request.args.get('type')
    if sdp_type == 'offer':
        result = jsonify(session['offer'])
    elif sdp_type == 'answer':
        result = jsonify(session['answer'])
    else:
        abort(400, "Invalid signal type requested.")
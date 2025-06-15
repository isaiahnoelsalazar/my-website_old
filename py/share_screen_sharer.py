"""
Sharer's page. Loaded when the QR code is scanned.
"""
result = ""
if session_id not in SESSIONS:
    abort(404, "Session not found.")
result = render_template('share.html', session_id=session_id)
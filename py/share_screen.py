"""
Viewer's page. Generates a session, a QR code, and waits for a connection.
"""
result = ""
session_id = str(uuid.uuid4())

# The URL the Android device will open after scanning.
# We use request.host_url to build the full public URL.
sharer_url = f"{request.host_url}share/{session_id}"

# Create the QR code in memory
img = qrcode.make(sharer_url)
buf = io.BytesIO()
img.save(buf, format='PNG')
qr_code_data = base64.b64encode(buf.getvalue()).decode('utf-8')
qr_code_data_uri = f"data:image/png;base64,{qr_code_data}"

# Initialize the session
SESSIONS[session_id] = {"offer": None, "answer": None}

print(f"Created session: {session_id}")
print(f"Sharer URL: {sharer_url}")

result = render_template(
    'index.html',
    session_id=session_id,
    qr_code_uri=qr_code_data_uri
)
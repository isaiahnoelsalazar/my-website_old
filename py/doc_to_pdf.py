if 'file' not in request.files:
    return redirect(request.url) # No file part
file = request.files['file']
if file.filename == '':
    return redirect(request.url) # No selected file
if file and allowed_file(file.filename):
    # Secure the filename and save the uploaded DOCX
    filename = secure_filename(file.filename)
    unique_filename = str(uuid.uuid4()) + "_" + filename
    docx_path = os.path.join(app.config['UPLOAD_FOLDER'], unique_filename)
    file.save(docx_path)

    # Generate a unique name for the output PDF
    pdf_filename = os.path.splitext(unique_filename)[0] + ".pdf"
    pdf_path = os.path.join(app.config['CONVERTED_FOLDER'], pdf_filename)
    
    # Convert the DOCX to PDF
    if convert_to_pdf(docx_path, pdf_path):
        # If conversion is successful, offer the PDF for download
        return send_file(pdf_path, as_attachment=True, download_name=pdf_filename)
    else:
        return "<h1>Error: DOCX to PDF conversion failed.</h1><p>Please check server logs for more details.</p>", 500
else:
    return "<h1>Error: Invalid file type. Only .docx files are allowed.</h1>", 400
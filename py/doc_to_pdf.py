result = None

if "file" not in request.files:
    result = redirect(request.url)

file = request.files["file"]

if file.filename == "":
    result = redirect(request.url)

if file and allowed_file(file.filename):
    filename = secure_filename(file.filename)
    # unique_filename = str(uuid.uuid4()) + "_" + filename
    docx_path = os.path.join(app.config["UPLOAD_FOLDER"], filename)
    file.save(docx_path)

    pdf_filename = os.path.splitext(filename)[0] + ".pdf"
    pdf_path = os.path.join(app.config["CONVERTED_FOLDER"], pdf_filename)

    if convert_to_pdf(docx_path, pdf_path):
        result = send_file("/home/sasasaia/" + app.config["CONVERTED_FOLDER"] + "/" + pdf_filename, as_attachment=True, download_name=pdf_filename)
        os.remove(docx_path)
        os.remove("/home/sasasaia/" + app.config["CONVERTED_FOLDER"] + "/" + pdf_filename)
    else:
        result = "<h1>Error: DOC to PDF conversion failed.</h1><p>Please check server logs for more details.</p>"
else:
    result = "<h1>Error: Invalid file type. Only *.doc or *.docx files are allowed.</h1>"
yt = YouTube("https://www.youtube.com/watch?v=" + url)

audio = yt.streams.filter(only_audio=True).first()
audio.download()

result = send_file(audio.title + ".mp3", as_attachment=True, download_name=audio.title + ".mp3")

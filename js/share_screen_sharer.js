const sessionId = "{{ session_id }}";
const startBtn = document.getElementById('start');
const statusEl = document.getElementById('status');

startBtn.onclick = async () => {
    try {
        startBtn.disabled = true;
        statusEl.textContent = 'Requesting screen access...';

        // 1. Get screen media
        const stream = await navigator.mediaDevices.getDisplayMedia({ video: true });
        
        // 2. Create Peer Connection
        const pc = new RTCPeerConnection();
        stream.getTracks().forEach(track => pc.addTrack(track, stream));

        // 3. Create offer and set local description
        const offer = await pc.createOffer();
        await pc.setLocalDescription(offer);
        statusEl.textContent = 'Sending offer...';

        // 4. Post offer to the server
        await fetch(`/api/signal/${sessionId}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ type: offer.type, sdp: offer.sdp })
        });
        statusEl.textContent = 'Offer sent. Waiting for answer...';
        
        // 5. Poll for the answer from the viewer
        let answer = null;
        while (!answer) {
            const response = await fetch(`/api/signal/${sessionId}?type=answer`);
            if (response.ok) {
                answer = await response.json();
            }
            if (!answer) {
                await new Promise(resolve => setTimeout(resolve, 2000));
            }
        }
        
        statusEl.textContent = 'Answer received. Connecting...';
        await pc.setRemoteDescription(answer);
        statusEl.textContent = 'Connection established!';
        startBtn.style.display = 'none';
    } catch (err) {
        console.error(err);
        statusEl.textContent = `Error: ${err.message}`;
        startBtn.disabled = false;
    }
};
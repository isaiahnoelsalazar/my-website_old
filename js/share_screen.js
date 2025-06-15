const sessionId = "{{ session_id }}";
const statusEl = document.getElementById('status');
const videoEl = document.getElementById('video');

async function connect() {
    // 1. Poll for the offer from the sharer
    statusEl.textContent = 'Status: Waiting for an offer from the sharer...';
    let offer = null;
    while (!offer) {
        const response = await fetch(`/api/signal/${sessionId}?type=offer`);
        if (response.ok) {
            offer = await response.json();
        }
        if (!offer) {
            await new Promise(resolve => setTimeout(resolve, 2000)); // Wait 2s
        }
    }
    statusEl.textContent = 'Status: Offer received. Creating answer...';

    // 2. Create Peer Connection and set up handlers
    const pc = new RTCPeerConnection();
    pc.ontrack = (event) => {
        statusEl.textContent = 'Status: Connected!';
        videoEl.srcObject = event.streams[0];
    };

    // 3. Set remote description (the offer) and create an answer
    await pc.setRemoteDescription(offer);
    const answer = await pc.createAnswer();
    await pc.setLocalDescription(answer);

    // 4. Send the answer back to the sharer
    await fetch(`/api/signal/${sessionId}`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ type: answer.type, sdp: answer.sdp })
    });
}

connect();
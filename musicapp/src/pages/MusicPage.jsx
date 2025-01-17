import React, { useEffect, useState } from "react";
import { getMusic } from "../services/musicService";

function MusicPage() {
    const [musicList, setMusicList] = useState([]);

    useEffect(() => {
        getMusic().then(setMusicList);
    }, []);

    return (
        <div>
            <h1>Music Page</h1>
            <ul>
                {musicList.map((music) => (
                    <li key={music.id}>{music.title} by {music.artist}</li>
                ))}
            </ul>
        </div>
    );
}

export default MusicPage;
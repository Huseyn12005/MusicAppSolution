import React, { useEffect, useState } from "react";
import { getFavorites } from "../services/favoritesService";

function FavoritesPage() {
    const [favorites, setFavorites] = useState([]);

    useEffect(() => {
        getFavorites().then(setFavorites);
    }, []);

    return (
        <div>
            <h1>Favorites Page</h1>
            <ul>
                {favorites.map((fav) => (
                    <li key={fav.id}>{fav.title}</li>
                ))}
            </ul>
        </div>
    );
}

export default FavoritesPage;
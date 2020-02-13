import React from 'react';
import PropTypes from "prop-types";

Ranks.propTypes = {
    ranks: PropTypes.array
};

export function Ranks({ ranks }) {
    return (
        <div className="row">
            <p>{ranks.length > 0 && "Top 100 Ranks:"}</p>
            {ranks.map((rank, i) => <div className="rank" key={i}>{rank}</div>)}
        </div>
    )
}
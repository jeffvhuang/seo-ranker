import React from 'react';
import PropTypes from "prop-types";

Ranks.propTypes = {
    ranks: PropTypes.array,
    isFetched: PropTypes.bool
};

export function Ranks({ ranks, isFetched }) {
    const ranksTitle = (ranks.length > 0) ? "Ranks in top 100 (including ads):"
        : (isFetched) ? "No match found in top 100"
        : "";

    return (
        <>
            <h4 className="ranks-title">{ranksTitle}</h4>
            <div className="row">
                {ranks.map((rank, i) => <div className="rank" key={i}>{rank}</div>)}
            </div>
        </>
    )
}
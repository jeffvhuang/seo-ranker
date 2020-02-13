import React from 'react';
import PropTypes from "prop-types";

Ranks.propTypes = {
    ranks: PropTypes.array
};

export function Ranks({ ranks }) {
    return (
        <>
            <h4 className="ranks-title">{ranks.length > 0 && "Ranks in Top 100 (including Ads):"}</h4>
            <div className="row">
                {ranks.map((rank, i) => <div className="rank" key={i}>{rank}</div>)}
            </div>
        </>
    )
}
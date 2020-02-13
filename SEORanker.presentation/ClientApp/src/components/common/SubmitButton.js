import React from 'react';
import PropTypes from "prop-types";
import { Button } from 'reactstrap';

SubmitButton.propTypes = {
    isLoading: PropTypes.bool
};

function SubmitButton({ isLoading }) {
    return isLoading
        ? <Button disabled>Submit</Button>
        : <Button color="primary" type="submit">Submit</Button>;
}

export default SubmitButton;
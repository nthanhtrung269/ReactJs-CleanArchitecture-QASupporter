import Axios from 'axios';
import {
    DBF2SQL_MAPPING_LIST_FAIL,
    DBF2SQL_MAPPING_LIST_REQUEST,
    DBF2SQL_MAPPING_LIST_SUCCESS
} from "../constants/dbf2SqlMappingConstants";
import { DBF2SQL_MAPPING_API_BASE_URL } from '../constants/environmentConstants';

export const getAllDbf2SqlMappingByKeyword = ({ keyword = '', modifiedBy = 'Admin' }) => async (dispatch, getState) => {
    dispatch({ type: DBF2SQL_MAPPING_LIST_REQUEST });
    const {
        userSignin: { userInfo },
    } = getState();
    try {
        const { data } = await Axios.get(`${DBF2SQL_MAPPING_API_BASE_URL}/api/dbf2sqlmapping/get-all?keyword=${keyword}&modifiedBy=${modifiedBy}`, {
            headers: { Authorization: `Bearer ${userInfo.token}` },
        });
        console.log(data);
        dispatch({ type: DBF2SQL_MAPPING_LIST_SUCCESS, payload: data });
    } catch (error) {
        const message =
            error.response && error.response.data.message
                ? error.response.data.message
                : error.message;
        dispatch({ type: DBF2SQL_MAPPING_LIST_FAIL, payload: message });
    }
};
import Axios from 'axios';
import {
    DBF2SQL_MAPPING_CREATE_FAIL,
    DBF2SQL_MAPPING_CREATE_REQUEST,
    DBF2SQL_MAPPING_CREATE_SUCCESS,
    DBF2SQL_MAPPING_DETAIL_FAIL,
    DBF2SQL_MAPPING_DETAIL_REQUEST,
    DBF2SQL_MAPPING_DETAIL_SUCCESS,
    DBF2SQL_MAPPING_LIST_FAIL,
    DBF2SQL_MAPPING_LIST_REQUEST,
    DBF2SQL_MAPPING_LIST_SUCCESS
} from "../constants/dbf2SqlMappingConstants";
import { DBF2SQL_MAPPING_API_BASE_URL } from '../constants/environmentConstants';

export const getAllDbf2SqlMappingByKeyword = ({ keyword = '', modifiedBy = 'Admin' }) => async (dispatch, getState) => {
    dispatch({ type: DBF2SQL_MAPPING_LIST_REQUEST });
    try {
        const { data } = await Axios.get(`${DBF2SQL_MAPPING_API_BASE_URL}/api/dbf2sqlmapping/get-all?keyword=${keyword}&modifiedBy=${modifiedBy}`);
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

export const getDbf2SqlMappingDetail = (dbf2SqlMappingId) => async (dispatch) => {
    dispatch({ type: DBF2SQL_MAPPING_DETAIL_REQUEST, payload: dbf2SqlMappingId });
    try {
        const { data } = await Axios.get(`/api/dbf2sqlmapping`);
        dispatch({ type: DBF2SQL_MAPPING_DETAIL_SUCCESS, payload: data });
    } catch (error) {
        dispatch({
            type: DBF2SQL_MAPPING_DETAIL_FAIL,
            payload:
                error.response && error.response.data.message
                    ? error.response.data.message
                    : error.message,
        });
    }
};

export const createDbf2SqlMapping = (dbf2SqlMapping) => async (dispatch) => {
    dispatch({ type: DBF2SQL_MAPPING_CREATE_REQUEST, payload: dbf2SqlMapping });
    try {
        const { data } = await Axios.post('/api/dbf2sqlmapping/add', dbf2SqlMapping, {
            headers: { Authorization: 'Bearer token...' },
          });
        dispatch({ type: DBF2SQL_MAPPING_CREATE_SUCCESS, payload: data });
    } catch (error) {
        dispatch({
            type: DBF2SQL_MAPPING_CREATE_FAIL,
            payload:
                error.response && error.response.data.message
                    ? error.response.data.message
                    : error.message,
        });
    }
};
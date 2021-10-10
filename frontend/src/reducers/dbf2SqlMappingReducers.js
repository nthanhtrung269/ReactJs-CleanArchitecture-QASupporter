import {
    DBF2SQL_MAPPING_CREATE_FAIL,
    DBF2SQL_MAPPING_CREATE_REQUEST,
    DBF2SQL_MAPPING_CREATE_RESET,
    DBF2SQL_MAPPING_CREATE_SUCCESS,
    DBF2SQL_MAPPING_DETAIL_FAIL,
    DBF2SQL_MAPPING_DETAIL_REQUEST,
    DBF2SQL_MAPPING_DETAIL_RESET,
    DBF2SQL_MAPPING_DETAIL_SUCCESS,
    DBF2SQL_MAPPING_EDIT_FAIL,
    DBF2SQL_MAPPING_EDIT_REQUEST,
    DBF2SQL_MAPPING_EDIT_RESET,
    DBF2SQL_MAPPING_EDIT_SUCCESS,
    DBF2SQL_MAPPING_LIST_FAIL,
    DBF2SQL_MAPPING_LIST_REQUEST,
    DBF2SQL_MAPPING_LIST_SUCCESS
} from "../constants/dbf2SqlMappingConstants";

export const getAllDbf2SqlMappingByKeywordReducer = (state = { dbf2SqlMappings: [] }, action) => {
    switch (action.type) {
        case DBF2SQL_MAPPING_LIST_REQUEST:
            return { loading: true };
        case DBF2SQL_MAPPING_LIST_SUCCESS:
            return { loading: false, dbf2SqlMappings: action.payload };
        case DBF2SQL_MAPPING_LIST_FAIL:
            return { loading: false, error: action.payload };
        default:
            return state;
    }
};

export const dbf2SqlMappingDetailsReducer = (state = { dbf2SqlMappings: [] }, action) => {
    switch (action.type) {
        case DBF2SQL_MAPPING_DETAIL_REQUEST:
            return { loading: true };
        case DBF2SQL_MAPPING_DETAIL_SUCCESS:
            return { loading: false, dbf2SqlMappingDetail: action.payload };
        case DBF2SQL_MAPPING_DETAIL_FAIL:
            return { loading: false, error: action.payload };
        case DBF2SQL_MAPPING_DETAIL_RESET:
            return {};
        default:
            return state;
    }
};

export const dbf2SqlMappingCreateReducer = (state = {}, action) => {
    switch (action.type) {
        case DBF2SQL_MAPPING_CREATE_REQUEST:
            return { loading: true };
        case DBF2SQL_MAPPING_CREATE_SUCCESS:
            return { loading: false, success: action.payload };
        case DBF2SQL_MAPPING_CREATE_FAIL:
            return { loading: false, error: action.payload };
        case DBF2SQL_MAPPING_CREATE_RESET:
            return {};
        default:
            return state;
    }
};

export const dbf2SqlMappingEditReducer = (state = {}, action) => {
    switch (action.type) {
        case DBF2SQL_MAPPING_EDIT_REQUEST:
            return { loading: true };
        case DBF2SQL_MAPPING_EDIT_SUCCESS:
            return { loading: false, success: action.payload };
        case DBF2SQL_MAPPING_EDIT_FAIL:
            return { loading: false, error: action.payload };
        case DBF2SQL_MAPPING_EDIT_RESET:
            return {};
        default:
            return state;
    }
};
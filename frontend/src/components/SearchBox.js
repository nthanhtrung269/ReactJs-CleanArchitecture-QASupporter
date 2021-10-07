import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { listUsers } from '../actions/userActions';
import LoadingBox from './LoadingBox';
import MessageBox from './MessageBox';

export default function SearchBox(props) {
  const keywordParam = new URLSearchParams(props.history.location.search).get("keyword");
  const modifiedByParam = new URLSearchParams(props.history.location.search).get("modifiedBy");

  const userList = useSelector((state) => state.userList);
  const { loading, error, users } = userList;

  const [keyword, setKeyword] = useState(keywordParam);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(listUsers());
  }, [dispatch]);

  const submitHandler = (e) => {
    e.preventDefault();
    props.history.push(getFilterUrl({ modifiedBy: modifiedByParam }));
  };

  const getFilterUrl = (filter) => {
    const filterModifiedBy = filter.modifiedBy || '';
    return `/dbf2sqlmapping/?keyword=${keyword}&modifiedBy=${filterModifiedBy}`;
  };

  return (
    <form className="search" onSubmit={submitHandler}>
      <div className="row">
        {loading ? (
          <LoadingBox></LoadingBox>
        ) : error ? (
          <MessageBox variant="danger">{error}</MessageBox>
        ) : (
          <select
            value={modifiedByParam}
            onChange={(e) => {
              props.history.push(getFilterUrl({ modifiedBy: e.target.value }));
            }}
          >
            <option value="">All Users</option>
            {users.map((user) => (
              <option key={user.UserId} value={user.UserName}>{user.UserName}</option>
            ))}
          </select>
        )}
        <input
          type="text"
          name="q"
          id="q"
          onChange={(e) => setKeyword(e.target.value)}
        ></input>
        <button className="primary" type="submit">
          <i className="fa fa-search"></i>
        </button>
      </div>
    </form>
  );
}

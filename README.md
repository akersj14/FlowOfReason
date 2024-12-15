# Flow Of Reason

## The Goal

The purpose of the Flow Of Reason (FOR) is to support people who want to logically trace out and organize arguments 
with supporting materials. The goal is also to allow a broader community to help build the logic graph. 
Many sites help with individual and unique questions, but I want to see how they all fit together.
There are also many books that cover similar ideas, and it feels pointless to read multiple books that have the 
same answers and ideas when the authors could simply make their case on this application with direct links to sources
and other generally accepted arguments rather than in the vacuum of a book.

## The public API

The API will be free to use for public logic trees. It will be limited to a TDB extent to allow the maximum number of
people access to it.

/LogicGraph/
/LogicGraph/{graph id}
/Node/{node id}
/LeadComment/{lead comment id}
/DiscussionComment/{discussion comment id}


## The private API

Via your account, you will have access to an API that allows you access to your own data. Now, this API is also
limited and will not allow your private knowledge trees to grow beyond X size.

## TODO

- [ ] Create initial API
- [ ] Create initial Data Bases using SqLite
- [ ] Use longer term Data Bases
- [ ] Add Authentication
- [ ] Add Authorization


class IndexedTextSearch:
    """
    :param statement_comparison_function: A comparison class.
        Defaults to ``LevenshteinDistance``.

    :param search_page_size:
        The maximum number of records to load into memory at a time when searching.
        Defaults to 1000
    """

    name = 'indexed_text_search'

    def __init__(self, chatbot, **kwargs):
        from chatterbot.comparisons import LevenshteinDistance

        self.chatbot = chatbot

        statement_comparison_function = kwargs.get(
            'statement_comparison_function',
            LevenshteinDistance
        )

        self.compare_statements = statement_comparison_function(
            language=self.chatbot.tagger.language
        )

        self.search_page_size = kwargs.get(
            'search_page_size', 1000
        )

    def search(self, input_statement, **additional_parameters):
        """
        Search for close matches to the input. Confidence scores for
        subsequent results will order of increasing value.

        :param input_statement: A statement.
        :type input_statement: chatterbot.conversation.Statement

        :param **additional_parameters: Additional parameters to be passed
            to the ``filter`` method of the storage adapter when searching.

        :rtype: Generator yielding one closest matching statement at a time.
        """
        self.chatbot.logger.info('Beginning search for close text match')

        search_parameters = {
            'search_in_response_to_contains': input_statement.search_text,
            'persona_not_startswith': 'bot:',
            'page_size': self.search_page_size
        }

        if additional_parameters:
            search_parameters.update(additional_parameters)

        statement_list = self.chatbot.storage.filter(**search_parameters)

        best_confidence_so_far = 0

        self.chatbot.logger.info('Processing search results')

        # Find the closest matching known statement
        for statement in statement_list:
            confidence = self.compare_statements.compare_text(
                input_statement.text, statement.in_response_to
            )

            if confidence > best_confidence_so_far:
                best_confidence_so_far = confidence
                statement.confidence = confidence

                self.chatbot.logger.info('Similar text found: {} {}'.format(
                    statement.in_response_to, confidence
                ))

                yield statement


class TextSearch:
    """
    :param statement_comparison_function: A comparison class.
        Defaults to ``LevenshteinDistance``.

    :param search_page_size:
        The maximum number of records to load into memory at a time when searching.
        Defaults to 1000
    """

    name = 'text_search'

    def __init__(self, chatbot, **kwargs):
        from chatterbot.comparisons import LevenshteinDistance

        self.chatbot = chatbot

        statement_comparison_function = kwargs.get(
            'statement_comparison_function',
            LevenshteinDistance
        )

        self.compare_statements = statement_comparison_function(
            language=self.chatbot.tagger.language
        )

        self.search_page_size = kwargs.get(
            'search_page_size', 1000
        )

    def search(self, input_statement, **additional_parameters):
        """
        Search for close matches to the input. Confidence scores for
        subsequent results will order of increasing value.

        :param input_statement: A statement.
        :type input_statement: chatterbot.conversation.Statement

        :param **additional_parameters: Additional parameters to be passed
            to the ``filter`` method of the storage adapter when searching.

        :rtype: Generator yielding one closest matching statement at a time.
        """
        self.chatbot.logger.info('Beginning search for close text match')

        search_parameters = {
            'persona_not_startswith': 'bot:',
            'page_size': self.search_page_size
        }

        if additional_parameters:
            search_parameters.update(additional_parameters)

        statement_list = self.chatbot.storage.filter(**search_parameters)

        best_confidence_so_far = 0

        self.chatbot.logger.info('Processing search results')

        # Find the closest matching known statement
        for statement in statement_list:
            confidence = self.compare_statements.compare_text(
                input_statement.text, statement.in_response_to
            )

            if confidence > best_confidence_so_far:
                best_confidence_so_far = confidence
                statement.confidence = confidence

                self.chatbot.logger.info('Similar text found: {} {}'.format(
                    statement.text, confidence
                ))

                yield statement


class VectorSearch:
    """
    .. note:: BETA feature: this search method is new and experimental.

    Search for similar text based on a :term:`vector database`.
    """

    name = 'vector_search'

    def __init__(self, chatbot, **kwargs):
        from chatterbot.storage import RedisVectorStorageAdapter

        # Good documentation:
        # https://python.langchain.com/docs/integrations/vectorstores/redis/
        #
        # https://hub.docker.com/r/redis/redis-stack

        # Mondodb:
        # > Vector Search is only supported on Atlas Clusters
        # https://www.mongodb.com/community/forums/t/can-a-local-mongodb-instance-be-used-when-working-with-langchain-mongodbatlasvectorsearch/265356

        # FAISS:
        # https://python.langchain.com/docs/integrations/vectorstores/faiss/

        print("Starting Redis Vector Store")

        # TODO: look into:
        # https://python.langchain.com/api_reference/redis/chat_message_history/langchain_redis.chat_message_history.RedisChatMessageHistory.html

        # The VectorSearch class is only compatible with the RedisVectorStorageAdapter
        if not isinstance(chatbot.storage, RedisVectorStorageAdapter):
            raise Exception(
                'The VectorSearch search method requires the RedisVectorStorageAdapter storage adapter.'
            )

    def search(self, input_statement, **additional_parameters):
        print("Querying Vector Store")

        # Similarity search with score and filter
        # NOTE: It looks like `return_all` is needed to return the full document
        # specifically what we need here is the ID
        scored_results = self.storage.vector_store.similarity_search_with_score(
            input_statement.text, k=2, return_all=True
        )
        # sort_by="score", filter={"category": "likes"})

        print("Similarity Search with Score Results:\n")
        for doc, score in scored_results:
            print(f"Content: {doc.page_content[:150]}...")
            print(f"ID: {doc.id}")
            print(f"Metadata: {doc.metadata}")
            print(f"Score: {score}")
            print()
